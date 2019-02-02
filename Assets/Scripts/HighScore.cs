using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    private GameSession gameSession;
    private int score;
    private Text scoreText;
    // Start is called before the first frame update
    void Start() {
        gameSession = FindObjectOfType<GameSession>();
        score = gameSession.GetScore();
        scoreText = gameObject.GetComponent<Text>();

        scoreText.text = score.ToString();
    }
}
