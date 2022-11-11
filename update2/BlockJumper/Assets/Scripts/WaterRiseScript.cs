using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRiseScript : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        rb = GetComponent<Rigidbody2D>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject character = GameObject.Find("character");
        if (character.GetComponent<Rigidbody2D>().velocity.y == 0 && character.GetComponent<Rigidbody2D>().position.y > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("killed");
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime,0); //allows the water to rise on the y axis or just rise up 
    }
    

}
