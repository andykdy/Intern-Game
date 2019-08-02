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
        spawned = true;
        player = FindObjectOfType<PlayerEntityBehaviour>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.AddScore(100);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blocks") && !other.gameObject.GetComponent<BlockBehaviour>().spawned)
        {
            Vector2 block = other.transform.position;
            Vector2 splitter = gameObject.transform.position;
            Vector2 trajectory = block - splitter;
            float newx = trajectory.x * Mathf.Cos(Mathf.PI/2)/2.0f;
            float newy = trajectory.x * Mathf.Sin(Mathf.PI/2)/2.0f;
            Vector2 newtrajectory = new Vector2(newx,newy);
            Vector2 leftPosition = (Vector2)other.transform.position + newtrajectory;
            Vector2 rightPosition = (Vector2) other.transform.position - newtrajectory;
            
            GameObject foobar = Instantiate(blockPrefab, new Vector3(leftPosition.x, leftPosition.y, -5), Quaternion.identity);
            GameObject barfoo = Instantiate(blockPrefab, new Vector3(rightPosition.x, rightPosition.y, -5), Quaternion.identity);
            foobar.transform.localScale *= 0.5f;
            barfoo.transform.localScale *= 0.5f;
            var mag = other.gameObject.GetComponent<BlockBehaviour>().getMagnitude();
            foobar.GetComponent<BlockBehaviour>().setMassValue(0.5f);
            barfoo.GetComponent<BlockBehaviour>().setMassValue(0.5f);
            foobar.GetComponent<BlockBehaviour>().setToSpawned();
            barfoo.GetComponent<BlockBehaviour>().setToSpawned();
            foobar.GetComponent<BlockBehaviour>().setVelocity(new Vector2(mag*trajectory.x* Mathf.Cos(Mathf.PI/6), mag*trajectory.y* Mathf.Sin(Mathf.PI/6)));
            barfoo.GetComponent<BlockBehaviour>().setVelocity(new Vector2(mag*trajectory.x* Mathf.Cos(-Mathf.PI/6), mag*trajectory.y* Mathf.Sin(-Mathf.PI/6)));
            other.gameObject.GetComponent<BlockBehaviour>().setToTriggered();
            Destroy(other.gameObject);
        }
        float velo = other.rigidbody.velocity.magnitude;
        Vector2 V2 = other.rigidbody.velocity;
        V2.x = (other.transform.position.x - transform.position.x) * 0.5f;
        V2.y = (other.transform.position.y - transform.position.y) * 0.5f;
        other.rigidbody.velocity = V2 * 2.0f;
    }
}
