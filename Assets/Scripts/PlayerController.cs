using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum PlayerState
    {
        Idle = 0,
        Moving = 1,
        Dragging = 2
    }

    private PlayerState currState;
    private Vector2 mousePosition;
    private Rigidbody2D rgbd;
    // Start is called before the first frame update
    void Start()
    {
        currState = PlayerState.Idle;
        rgbd = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0) && currState == PlayerState.Dragging)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pushDir = 200 *((Vector2) gameObject.transform.position - mousePosition);
            rgbd.AddForce(pushDir);
        }
        
        rgbd.AddForce(rgbd.velocity * -0.5f);
    }
    
    private void OnMouseDrag()
    {
        currState = PlayerState.Dragging;
    }


    private void OnMouseDown()
    {
        rgbd.velocity = Vector2.zero;
    }
}
