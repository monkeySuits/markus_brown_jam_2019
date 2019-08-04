using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowShooter : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject arrowPrefab;

    public float timeToSpawn;
    float curTime;

    // Update is called once per frame
    void Update()
    {
        if(curTime <= timeToSpawn)
        {
            curTime += Time.deltaTime;
        }
        else
        {
            SpawnArrow();
            curTime = 0;
        }
    }

    void SpawnArrow()
    {
        Instantiate(arrowPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)]);
    }
}
