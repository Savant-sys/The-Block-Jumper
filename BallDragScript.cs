using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BallDragScript : MonoBehaviour
{
    public Animator animator;
    
    public BallDragScript instance;

    public float BallPower;
    public Rigidbody2D rb;

    public Vector2 minimumpower;
    public Vector2 maximumpower;

    TrajectoryLine tl;
    bool facingRight = true;

    Camera cam;
    Vector2 ballforce;
    Vector3 startpoint;
    Vector3 endpoint;

    Vector3 camOffset = new Vector3(0, 0, 10);

    public bool isGrounded = false;
    public bool isOnPlatform = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name != "coinGold")
        {
            isGrounded = true;
            Debug.Log("Landed");
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name != "coinGold")
        {
            isGrounded = false;
            Debug.Log("Jumped");
        }
      
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update()
    {
        float vert_speed = rb.velocity.y;
        float horiz_speed = rb.velocity.x;
        animator.SetFloat("y_velocity", vert_speed);
        animator.SetBool("Is_Grounded", isGrounded);

        if (horiz_speed < 0 && facingRight &&!isGrounded) flip();
        if (horiz_speed > 0 && !facingRight &&!isGrounded) flip();

        if (isGrounded)
        {
            animator.SetBool("Falling", true);
        }

        if (Input.GetMouseButtonDown(0) && !isOnPlatform)
            {
                animator.SetBool("Is_Charging", true);
                startpoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startpoint.z = 15;
                tl.lr.numCapVertices = 10;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 currentpoint = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
                currentpoint.z = 15;
                tl.RenderLine(startpoint, currentpoint);
            }

            if (Input.GetMouseButtonUp(0))
            {
                endpoint = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
                endpoint.z = 15;

                ballforce = new Vector2(Mathf.Clamp(startpoint.x - endpoint.x, minimumpower.x, maximumpower.x),
                    Mathf.Clamp(startpoint.y - endpoint.y, minimumpower.y, maximumpower.y));
                rb.AddForce(ballforce * BallPower, ForceMode2D.Impulse);
                tl.endline();
            }
        if (!isGrounded)
        {
            animator.SetBool("Is_Charging", false);
        }
        if (!isGrounded && (vert_speed == 0))
        {
            animator.SetBool("Falling", true);
        }

      
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
