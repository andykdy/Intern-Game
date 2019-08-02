using System.Collections;
using System.Collections.Generic;
using Fungus;
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
    private float numOfMoves;
    private float currScene;
    private float highestVel;

    public static PlayerController instance = null;
    // Start is called before the first frame update
    void Start()
    {
        currState = PlayerState.Idle;
        rgbd = GetComponent<Rigidbody2D>();
        numOfMoves = 3;
        currScene = 0;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            instance.numOfMoves = 3;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (numOfMoves == 0 && rgbd.velocity.magnitude < 0.2f && highestVel > rgbd.velocity.magnitude)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }

        highestVel = Mathf.Max(highestVel, rgbd.velocity.magnitude);
        
        rgbd.AddForce(rgbd.velocity * -0.5f);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.transform.position = new Vector3(0f,-3f,-1f);
        rgbd.velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("PlayerEntity").GetComponent<PlayerEntityBehaviour>().LoseLife();
    }

    private void OnMouseUp()
    {
        if (currState == PlayerState.Dragging)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pushDir = 200 * ((Vector2) gameObject.transform.position - mousePosition);
            rgbd.AddForce(pushDir);
            numOfMoves--;
            currState = PlayerState.Idle;
        }
    }

    private void OnMouseDown()
    {
        if (numOfMoves <= 0)
            return;
        if (currState == PlayerState.Idle)
        {
            currState = PlayerState.Dragging;
            rgbd.velocity = Vector2.zero;
            mousePosition = gameObject.transform.position;
            highestVel = 0;
        }
    }
}
