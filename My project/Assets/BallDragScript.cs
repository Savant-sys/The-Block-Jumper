using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BallDragScript : MonoBehaviour
{
    public float BallPower;
    public Rigidbody2D rb;

    public Vector2 minimumpower;
    public Vector2 maximumpower;
    public LineRenderer line;
    Camera camera;
    Vector2 ballforce;
    Vector3 startpoint;
    Vector3 endpoint;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }


    public bool isGrounded = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
        Debug.Log("Landed");
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        isGrounded = false;
        Debug.Log("Jumped");
    }

    void Start()
    {
        camera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            startpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            startpoint.z = 15;
            line.numCapVertices = 10;
        }
        if (Input.GetMouseButton(0) && isGrounded == true)
        {
            Vector3 currentpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            currentpoint.z = 15;
            Drawlint(startpoint, currentpoint);
        }
        if (Input.GetMouseButtonUp(0) && isGrounded == true)
        {
            endpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            endpoint.z = 15;

            ballforce = new Vector2(Mathf.Clamp(startpoint.x - endpoint.x, minimumpower.x, maximumpower.x), 
                Mathf.Clamp(startpoint.y - endpoint.y, minimumpower.y, maximumpower.y));
            rb.AddForce(ballforce * BallPower, ForceMode2D.Impulse);
            endline();
        }
    }

    public void Drawlint(Vector3 startpoint, Vector3 endpoint)
    {
        line.positionCount = 2;
        Vector3[] Allpoint = new Vector3[2];
        Allpoint[0] = startpoint;
        Allpoint[1] = endpoint;
        line.SetPositions(Allpoint);
    }

    public void endline()
    {
        line.positionCount = 0;
    }
}