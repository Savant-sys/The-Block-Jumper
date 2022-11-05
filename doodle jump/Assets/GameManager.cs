using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    
    public int platformCount;
    Vector3 spawnPosition = new Vector3();
    double timer = 0;
    void spawnPlatform()
    {
        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(2f, 3.5f);
            spawnPosition.x = Random.Range(-5f, 5f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }


    public GameObject birdToSpawn;

    public int birdCount;
    Vector3 spawnPosBird = new Vector3();
    
    void spawnBirds()
    {
        for (int i = 0; i < birdCount; i++)
        {
            spawnPosBird.y += Random.Range(5f, 10f);
            spawnPosBird.x = Random.Range(-10f, 10f);
            bool outside = true;
            while (outside == true)
            {
                if (spawnPosBird.x > -6f && spawnPosBird.x <= 6f)
                {
                    spawnPosBird.x = Random.Range(-10f, 10f);
                }
                else
                {
                    outside = false;
                }
            }
            
            Instantiate(birdToSpawn, spawnPosBird, Quaternion.identity);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        platformCount = 50;
        birdCount = 20;
        spawnPlatform();
        spawnBirds();
    }

    // Update is called once per frame
    void Update()
    {
        timer += .01;
        if (timer > 100)
        {
            spawnPlatform();
            spawnBirds();
            timer = 0;
        }
    }
}
