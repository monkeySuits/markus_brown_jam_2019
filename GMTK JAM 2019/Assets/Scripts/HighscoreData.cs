using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreData {
    public int highscore;

    public HighscoreData(int _highscore) {
        highscore = _highscore;
    }
}