using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpikes : MonoBehaviour {
    float waitTime;
    public float minTimeToSpike = 1;
    public float maxTimeToSpike = 4;
    public float delayAfterWarning;

    float curTime = 0;

    public bool isActive;
    public float activatedTime;
    bool trapActive;

    void OnEnable() {
        MatchManager.instance.ActivateTrapEvent += Activate;
    }

    void OnDisable() {
        MatchManager.instance.ActivateTrapEvent -= Activate;
    }

    void Activate(bool _active) {
        trapActive = _active;
    }

    void Start() {
        curTime = 0;
        waitTime = Random.Range(minTimeToSpike, maxTimeToSpike);
    }

    void Update() {
        Debug.Log(isActive);

        if (trapActive) {
            if (!isActive) {
                if (curTime <= waitTime) {
                    curTime += Time.deltaTime;
                    if (curTime >= waitTime - delayAfterWarning)
                        Debug.Log("WARNING");
                }
                else {
                    StartCoroutine(ActivateDelay());
                    curTime = 0;
                    //waitForActivation = false;
                }
            }
        }
    }

    IEnumerator ActivateDelay() {
        isActive = true;
        GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(activatedTime);


        isActive = false;
        GetComponent<Renderer>().material.color = Color.green;
        waitTime = Random.Range(minTimeToSpike, maxTimeToSpike);
    }
}