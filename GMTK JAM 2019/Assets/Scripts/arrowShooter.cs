using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowShooter : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject arrowPrefab;
    public float timeToSpawn;

    float curTime;
    bool active;

    void OnEnable() {
        MatchManager.instance.ActivateTrapEvent += Activate;
    }

    void OnDisable() {
        MatchManager.instance.ActivateTrapEvent -= Activate;
    }

    void Activate(bool _active) {
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
        Instantiate(arrowPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)]);
    }    
}