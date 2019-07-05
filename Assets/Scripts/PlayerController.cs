using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static PlayerController instance = null;
    // Start is called before the first frame update
    void Start()
    {
        currState = PlayerState.Idle;
        rgbd = GetComponent<Rigidbody2D>();    
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)    
            Destroy(gameObject); 
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
    
    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.transform.position = new Vector3(0f,-2.5f,-1f);
        rgbd.velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("PlayerEntity").GetComponent<PlayerEntityBehaviour>().LoseLife();
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
