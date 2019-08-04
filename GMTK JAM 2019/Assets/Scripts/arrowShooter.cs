using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowShooter : MonoBehaviour {
    public Transform[] spawnPoints;
    public ArrowMovement arrowPrefab;
    public float arrowSpeed;

    public float timeToSpawn;    

    float curTime;
    bool active;

    ArrowMovement arrowClone;

    public void Activate(bool _active) {
        active = _active;
    }

    void Update() {
        if (active) {
            if (curTime <= timeToSpawn) {
                curTime += Time.deltaTime;
            }
            else {
                SpawnArrow();
                curTime = 0;
            }
        }
    }

    void SpawnArrow() {
        arrowClone = Instantiate(arrowPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)]);
        Destroy(arrowClone.gameObject, 8f);
        arrowClone.speed = arrowSpeed;
    }    
}