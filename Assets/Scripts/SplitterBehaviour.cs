using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SplitterBehaviour : BlockBehaviour
{
    public GameObject blockPrefab;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        Spawned = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blocks") && !other.gameObject.GetComponent<BlockBehaviour>().Spawned)
        {
            Vector2 block = other.transform.position;
            Vector2 splitter = gameObject.transform.position;
            Vector2 trajectory = block - splitter;
            float newx = trajectory.y/2;
            float newy = trajectory.x/2;
            Vector2 newtrajectory = new Vector2(newx,newy);
            Vector2 leftPosition = (Vector2)other.transform.position + newtrajectory;
            Vector2 rightPosition = (Vector2) other.transform.position - newtrajectory;
            
            GameObject foobar = Instantiate(blockPrefab, new Vector3(leftPosition.x, leftPosition.y, 0), Quaternion.identity);
            GameObject barfoo = Instantiate(blockPrefab, new Vector3(rightPosition.x, rightPosition.y, 0), Quaternion.identity);
            foobar.transform.localScale *= 0.5f;
            barfoo.transform.localScale *= 0.5f;
            foobar.GetComponent<BlockBehaviour>().setToSpawned();
            barfoo.GetComponent<BlockBehaviour>().setToSpawned();
            Destroy(other.gameObject);
        }
        float velo = other.rigidbody.velocity.magnitude;
        Vector2 V2 = other.rigidbody.velocity;
        V2.x = (float) ((other.transform.position.x - transform.position.x) * 0.5);
        V2.y = (float) ((other.transform.position.y - transform.position.y) * 0.5);
        other.rigidbody.velocity = V2;
        if (other.rigidbody.velocity.magnitude < velo)
        {
            other.rigidbody.velocity *= velo / other.rigidbody.velocity.magnitude;
        }
        
    }
}
