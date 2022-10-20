using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManagerScript : MonoBehaviour
{

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) ) {
            // We clicked on something

            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

            Debug.Log (mousePos2D);

            Vector2 dir = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
            if(hit != null && hit.collider != null) {
                // We clicked on SOMETHING that has a collider
                if(hit.collider.GetComponent<Rigidbody2D>() != null) {
                    hit.collider.GetComponent<Rigidbody2D>().gravityScale = 1;
                    rb = hit.collider.GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                }
            }
        }
    }
}
