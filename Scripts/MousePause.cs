using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePause : MonoBehaviour
{

    public Rigidbody2D rb;
    public Canvas pauseScreen;
    GameObject character;
    // Update is called once per frame
    private void Start()
    {
        character = GameObject.Find("character");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) ) {
            // We clicked on something

            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

            Debug.Log (mousePos2D);

            Vector2 dir = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
            if(hit != false) {
                // We clicked on SOMETHING that has a collider
                Debug.Log(hit.rigidbody.gameObject.tag);
                if(hit.rigidbody.tag == "Pause") {
                    character.GetComponent<CharacterMovement>().paused = true;
                    pauseScreen.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                }
                if (hit.rigidbody.tag == "Resume")
                {
                   
                    pauseScreen.gameObject.SetActive(false);
                    Time.timeScale = 1f;
                    character.GetComponent<CharacterMovement>().paused = false;
                }
            }
        }
    }
}
