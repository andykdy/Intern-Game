using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    protected Rigidbody2D rgbd;
    // Start is called before the first frame update
    public bool spawned;
    public bool triggered;
    protected PlayerEntityBehaviour player;
    protected float bounceMagnitude;
    protected void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerEntityBehaviour>();
        triggered = false;
        bounceMagnitude = 2.0f;
    }

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerEntityBehaviour>();
        triggered = false;
        bounceMagnitude = 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rgbd.AddForce(rgbd.velocity * -0.5f);
    }


    protected void OnTriggerExit2D(Collider2D other)
    {
        var scoreToAdd = triggered? 0 : spawned ? 75 : 100;
        player.AddScore(scoreToAdd);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Splitter"))
        {
            return;
        }
        Vector2 V2 = other.rigidbody.velocity;
        V2.x = (float)((other.transform.position.x - transform.position.x));
        V2.y = (float)((other.transform.position.y - transform.position.y));
        other.rigidbody.velocity = V2;
    }

    public void setToSpawned()
    {
        spawned = true;
    }

    public void setToTriggered()
    {
        triggered = true;
    }

    public void setMassValue(float massVal)
    {
        rgbd.mass = massVal;
    }

    public void setVelocity(Vector2 vel)
    {
        rgbd.velocity = vel;
    }
    public float getMagnitude()
    {
        return rgbd.velocity.magnitude;
    }
    
}
