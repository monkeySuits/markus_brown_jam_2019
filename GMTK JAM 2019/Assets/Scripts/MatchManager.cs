using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {
    public static MatchManager instance;

    [SerializeField] ArrowShooterManager arrowManager;
    [SerializeField] groundSpikes spikes;
    int score;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    public void StartGame() {
        //activate traps
        arrowManager.Activate(true);
        spikes.Activate(true);

        //resets score
        score = 0;

        //update canvas
        UIManager.instance.StartGame();
    }

    public void CountJump(int multiplier) {
        score += (1 * multiplier);
        UIManager.instance.CountJump(score);
    }

    public void EndGame() {
        arrowManager.Activate(false);
        spikes.Activate(false);

        int previousScore = SaveSystem.LoadHighscore();

        if (score > previousScore) {
            SaveSystem.SaveHighscore(score);
        }

        UIManager.instance.EndGame(score, previousScore);
    }
}