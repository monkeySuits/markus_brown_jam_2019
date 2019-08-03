using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpikes : MonoBehaviour
{
    float waitTime;
    public float minTimeToSpike = 1;
    public float maxTimeToSpike = 4;
    public float delayAfterWarning;

    float curTime = 0;

    public bool isActive;
    bool waitForActivation = true;
    public float activatedTime;

    float curActivatedTime = 0;

    bool waitForDeactivation;

    // Start is called before the first frame update
    void Start()
    {
        curTime = 0;
        waitTime = Random.Range(minTimeToSpike, maxTimeToSpike);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isActive);

        if (!isActive)
        {
            if (curTime <= waitTime)
            {
                curTime += Time.deltaTime;
                if (curTime >= waitTime - delayAfterWarning)
                    Debug.Log("WARNING");
            }
            else
            {
                StartCoroutine(ActivateDelay());
                curTime = 0;
                //waitForActivation = false;
            }
        }
    }

    IEnumerator ActivateDelay()
    {
        isActive = true;
        GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(activatedTime);


        isActive = false;
        GetComponent<Renderer>().material.color = Color.green;
        waitTime = Random.Range(minTimeToSpike, maxTimeToSpike);
    }
}
