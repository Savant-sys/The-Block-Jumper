using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    private float min_X = -4.5f, max_X = 4.5f;

    public bool canMove;
    private float move_Speed = 4f;

    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;


    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
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

    void RestartGame() {
        GameplayController.instance.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target) {
        if(ignoreCollision)
            return;

        if(target.gameObject.tag == "Platform") {
            Invoke("Landed", 0f);
            GameObject character = GameObject.Find("character");
            //character.GetComponent<BallDragScript>().isOnPlatform2 = false;
            ignoreCollision = true;
        }

        if(target.gameObject.tag == "Box") {
            Invoke("Landed", 0f);
            ignoreCollision = true;
        }
    }

}
