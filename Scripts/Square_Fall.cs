using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Fall : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, speed = Time.deltaTime,0); //allows the water to rise on the y axis or just rise up 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        /*if (other.gameObject.tag == "Platform")
        {
            Square.transform.parent = other.gameObject.transform;

        }
        */
    }
    
}
