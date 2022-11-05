using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    int total_score;
    private void OnCollisionEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
