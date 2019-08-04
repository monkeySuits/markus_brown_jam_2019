using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    [SerializeField] GameObject startScreen;
    TextMeshProUGUI startScore, startScoreShadow;

    [SerializeField] GameObject endScreen;
    TextMeshProUGUI endScore, endScoreShadow;
    TextMeshProUGUI highscore, highscoreShadow;
    GameObject newRecord;

    [Space]

    [SerializeField] GameObject gameScreen;
    TextMeshProUGUI jumpCounter;
    TextMeshProUGUI jumpCounterShadow;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    void Start() {
        //start screen refs
        startScore = startScreen.transform.Find("Score").GetComponent<TextMeshProUGUI>();
        startScoreShadow = startScreen.transform.Find("ScoreShadow").GetComponent<TextMeshProUGUI>();

        //end screen refs
        endScore = endScreen.transform.Find("Score").GetComponent<TextMeshProUGUI>();
        endScoreShadow = endScreen.transform.Find("ScoreShadow").GetComponent<TextMeshProUGUI>();
        highscore = endScreen.transform.Find("Highscore").GetComponent<TextMeshProUGUI>();
        highscoreShadow = endScreen.transform.Find("HighscoreShadow").GetComponent<TextMeshProUGUI>();
        newRecord = endScreen.transform.Find("NewRecord").gameObject;

        //game screen refs
        jumpCounter = gameScreen.transform.Find("Counter").GetComponent<TextMeshProUGUI>();
        jumpCounterShadow = gameScreen.transform.Find("Shadow").GetComponent<TextMeshProUGUI>();

        //load previous attempts
        int previousScore = SaveSystem.LoadHighscore();
        startScore.text = previousScore.ToString();
        startScoreShadow.text = previousScore.ToString();
    }

    public void StartGame() {
        startScreen.SetActive(false);
        endScreen.SetActive(false);
        gameScreen.gameObject.SetActive(true);
    }

    public void EndGame(int _score, int _previousScore) {
        gameScreen.gameObject.SetActive(false);
        endScreen.SetActive(true);

        //set all info and shadows
        newRecord.SetActive(_score > _previousScore);
        _previousScore = _score > _previousScore ? _score : _previousScore;

        endScore.text = _score.ToString();
        endScoreShadow.text = _score.ToString();

        highscore.text = _previousScore.ToString();
        highscoreShadow.text = _previousScore.ToString();                
    }

    public void CountJump(int count) {
        jumpCounter.text = count.ToString();
        jumpCounterShadow.text = count.ToString();
    }
}