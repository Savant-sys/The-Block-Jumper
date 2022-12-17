using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameplayController : MonoBehaviour
{
   
    public static GameplayController instance;

    public BoxSpawner box_Spawner;

    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;

    void Awake() {
        if (instance == null)
            instance = this;
      
    }

    // Start is called before the first frame update
    void Start()
    {
        box_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput() {
        GameObject character = GameObject.Find("character");
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            &&
            (character.GetComponent<CharacterMovement>().isGrounded)
            &&
            (character.GetComponent<CharacterMovement>().isOnPlatform) ) {
            currentBox.DropBox();
            character.GetComponent<CharacterMovement>().isOnPlatform = false;
        }
        else if ((Input.GetMouseButtonDown(0))
            &&
            (character.GetComponent<CharacterMovement>().isGrounded)
            &&
            (character.GetComponent<CharacterMovement>().isOnPlatform))
        {
            currentBox.DropBox();
            character.GetComponent<CharacterMovement>().isOnPlatform = false;
        }
    }

    public void SpawnNewBox(){
        Invoke("NewBox", .5f);
    }

    void NewBox() {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera(){
        moveCount++;

        if(moveCount == 3){
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }
    }
}
