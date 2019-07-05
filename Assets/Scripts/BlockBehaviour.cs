using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    protected Rigidbody2D rgbd;
    // Start is called before the first frame update
    public bool Spawned;
    protected PlayerEntityBehaviour player;
    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.velocity += new Vector2(Random.Range(0,1),Random.Range(0,1));
    }

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerEntityBehaviour>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rgbd.AddForce(rgbd.velocity * -0.5f);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        var scoreToAdd = Spawned ? 50 : 100;
        player.AddScore(scoreToAdd);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.name.Contains("Block") && other.gameObject.name.Contains("Splitter"))
        {
            return;
        }
        float velo = other.rigidbody.velocity.magnitude;
        Vector2 V2 = other.rigidbody.velocity;
        V2.x = (float)((other.transform.position.x - transform.position.x)* 0.8);
        V2.y = (float)((other.transform.position.y - transform.position.y)* 0.8);
        other.rigidbody.velocity = V2;
        if(other.rigidbody.velocity.magnitude < velo)
        {
            other.rigidbody.velocity *= velo/other.rigidbody.velocity.magnitude;
        }
    }

    public void setToSpawned()
    {
        Spawned = true;
    }

    public void setMassValue(float massVal)
    {
        rgbd.mass = massVal;
    }
}
