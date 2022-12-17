using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    AudioSource jumpsound;
    public Animator animator;
    
    public CharacterMovement instance;
    public float height = -3.4f;
    public Rigidbody2D rb2;
    public float jumpforce;
    public bool isOnPlatform2 = false;
    public bool paused;
    bool facingRight = true;

    Camera cam;

    Vector3 camOffset = new Vector3(0, 0, 10);

    public bool isGrounded = false;
    public bool isOnPlatform = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
        rb2 = GetComponent<Rigidbody2D>();
        jumpforce = 1000;
        jumpsound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (paused) return;
        float vert_speed = rb2.velocity.y;
        float horiz_speed = rb2.velocity.x;
        animator.SetFloat("y_velocity", vert_speed);
        animator.SetBool("Is_Grounded", isGrounded);

        if (horiz_speed < 0 && facingRight &&!isGrounded) flip();
        if (horiz_speed > 0 && !facingRight &&!isGrounded) flip();

        if (isGrounded)
        {
            animator.SetBool("Falling", true);
        }
        if (isOnPlatform) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Began && isGrounded == true && isOnPlatform2 == false)
            {
            Debug.Log(isOnPlatform);

                rb2.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
            jumpsound.Play();

        }
        else if (Input.GetMouseButtonDown(0) && isGrounded == true && isOnPlatform2 == false)
        {
            rb2.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
            jumpsound.Play();
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
    private void OnCollisionExit2D(Collision2D collision)
    {
            isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Bird")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Bird")
        {
            isGrounded = true;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
