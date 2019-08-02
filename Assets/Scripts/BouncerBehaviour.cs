using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerBehaviour : BlockBehaviour
{
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerEntityBehaviour>();
        bounceMagnitude = 6.0f;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        player.AddScore(100);
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
        other.rigidbody.velocity =  other.gameObject.name.Contains("Player")? V2 * bounceMagnitude: V2;
    }
}
