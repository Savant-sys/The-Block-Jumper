using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void End()
    {
        SceneManager.LoadScene("First_Cut");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            End();
        }

        if (col.gameObject.tag == "Box")
        {
            End();
        }
    }
}
