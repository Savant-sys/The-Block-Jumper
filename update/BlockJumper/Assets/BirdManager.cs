using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{

    double timer = 0;


    public GameObject birdToSpawn;
    public GameObject coin;

    public int birdCount, coinCount;
    Vector3 spawnPosBird = new Vector3();
    Vector3 spawnCoin = new Vector3();
    void spawnBirds()
    {
        for (int i = 0; i < birdCount; i++)
        {
            spawnPosBird.y += Random.Range(3f, 6f);
            spawnPosBird.x = Random.Range(-4f, 4f);
           

            Instantiate(birdToSpawn, spawnPosBird, Quaternion.identity);

        }
    }
    void spawnCoins()
    {
        for (int i = 0; i < birdCount; i++)
        {
            spawnCoin.y += Random.Range(2f, 5f);
            spawnCoin.x = Random.Range(-4f, 4f);


            Instantiate(coin, spawnCoin, Quaternion.identity);

        }
    }

    // Start is called before the first frame update
    void Start()
    {

        birdCount = 20;

        spawnBirds();
    }

    // Update is called once per frame
    void Update()
    {
        timer += .01;
        if (timer > 100)
        {
            spawnBirds();

            timer = 0;
        }
    }
}
