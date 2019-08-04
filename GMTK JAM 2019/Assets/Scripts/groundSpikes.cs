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

    Animator anim;

    [SerializeField] AudioClip trapSound;

    public void Activate(bool _active) {
        anim.SetTrigger("Hidden");
        trapActive = _active;
        curTime = 0;
    }

    void Start() {
        anim = GetComponent<Animator>();

        curTime = 0;
        waitTime = Random.Range(minTimeToSpike, maxTimeToSpike);
    }

    void Update() {
        if (trapActive) {
            if (!isActive) {
                if (curTime <= waitTime) {
                    curTime += Time.deltaTime;
                    if (curTime >= waitTime - delayAfterWarning) {
                        anim.SetTrigger("Warning");
                        Debug.Log("WARNING");
                    }
                }
                else {
                    StartCoroutine(ActivateDelay());
                    curTime = 0;
                }
            }
        }
    }

    IEnumerator ActivateDelay() {
        isActive = true;
        AudioManager.instance.PlayClip(trapSound);
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(activatedTime);

        isActive = false;
        anim.SetTrigger("Hidden");
        waitTime = Random.Range(minTimeToSpike, maxTimeToSpike);
    }
}