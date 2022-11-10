using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRiseScript : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed = Time.deltaTime,0); //allows the water to rise on the y axis or just rise up 
    }
    

}
