using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    public static AudioManager instance; //static instance can be called any time   
    AudioSource sourceFX;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    void Start() {
        sourceFX = GetComponent<AudioSource>();
    }

    //UI sounds
    public void PlayClip(AudioClip clip) {
        sourceFX.PlayOneShot(clip);
    }
}