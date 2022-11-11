using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlayer : MonoBehaviour
{
    private GameObject target = null;
    private Vector3 offset;
     void Start(){
        target = null;
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    void OnTriggerStay2D(Collider2D col){
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            GameObject character = GameObject.Find("character");
            character.GetComponent<BallDragScript>().isOnPlatform = true;
        }
        target = col.gameObject;
        offset = target.transform.position - transform.position;
     }
     void OnTriggerExit2D(Collider2D col){
        GameObject character = GameObject.Find("character");
        character.GetComponent<BallDragScript>().isOnPlatform = false;
        target = null;
     }
     void LateUpdate(){
         if (target != null) {
             target.transform.position = transform.position+offset;
         }
     }
}
