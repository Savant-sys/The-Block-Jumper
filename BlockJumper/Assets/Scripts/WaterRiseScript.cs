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

        rb = GetComponent<Rigidbody2D>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "character")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            Debug.Log("killed");
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime,0); //allows the water to rise on the y axis or just rise up 
    }
    

}
