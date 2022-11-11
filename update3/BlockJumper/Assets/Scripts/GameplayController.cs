using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            (character.GetComponent<BallDragScript>().isGrounded)
            &&
            (character.GetComponent<BallDragScript>().isOnPlatform) ) {
            currentBox.DropBox();
            character.GetComponent<BallDragScript>().isOnPlatform = false;
        }
    }

    public void SpawnNewBox(){
        Invoke("NewBox", 2f);
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

    public void RestartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
