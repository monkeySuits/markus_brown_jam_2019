using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject endScreen;

    [Space]

    [SerializeField] TextMeshProUGUI jumpCounter;
    
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    public void StartGame() {
        startScreen.SetActive(false);
        jumpCounter.gameObject.SetActive(true);
    }

    public void EndGame() {
        endScreen.SetActive(true);
        jumpCounter.gameObject.SetActive(false);
    }

    public void CountJump(int count) {
        jumpCounter.text = count.ToString();
    }
}