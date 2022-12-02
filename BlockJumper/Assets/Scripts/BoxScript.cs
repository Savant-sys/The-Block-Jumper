using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxScript : MonoBehaviour
{

    private float min_X = -4.5f, max_X = 4.5f;

    public bool canMove;
    private float move_Speed = 4f;

    private Rigidbody2D myBody;
    private SpriteRenderer myColor;
    private bool gameOver;
    public bool ignoreCollision;
    private bool ignoreTrigger;


    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
        myColor = GetComponent<SpriteRenderer>();

        myColor.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        GameplayController.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    void MoveBox(){
        if(canMove) {
            Vector3 temp = transform.position;

            temp.x += move_Speed * Time.deltaTime;

            if(temp.x >= max_X){
                move_Speed *= -1f;
            } else if (temp.x <= min_X) {
                move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBox(){
        canMove = false;
        myBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        myBody.gravityScale = Random.Range(2, 4);

    }

    void Landed(){
        if(gameOver){
            return;
        }

        ignoreCollision = true;
        ignoreTrigger = true;

        GameplayController.instance.SpawnNewBox();
        GameplayController.instance.MoveCamera();
    }

    void OnCollisionStay2D(Collision2D target) {
        GameObject character = GameObject.Find("character");

        if (ignoreCollision)
        {
            if (target.gameObject.tag == "Platform")
            {
                Debug.Log("platform detected");
                
                character.GetComponent<BallDragScript>().isOnPlatform2 = false;
            }
            return;
        }

        if (target.gameObject.name == "character")
        {
            Debug.Log("platform changed");
            character.GetComponent<BallDragScript>().isOnPlatform2 = true;
        }
        
        if (target.gameObject.tag == "Platform") {
            ScoreManager.instance.AddPoint();
            Invoke("Landed", 0f);
            ignoreCollision = true;
        }

        if(target.gameObject.tag == "Box")
        {
            ScoreManager.instance.AddPoint();
            Invoke("Landed", 0f);
            ignoreCollision = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject character = GameObject.Find("character");
        character.GetComponent<BallDragScript>().isOnPlatform2 = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject character = GameObject.Find("character");
        if (collision.gameObject.tag == "character")
        {
            ParticleSystem particles = character.GetComponentInChildren<ParticleSystem>();
        }
    }
}

