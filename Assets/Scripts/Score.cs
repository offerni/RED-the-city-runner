using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	Text score;
    int scoreSpeed = 2;
	GameSession gameSession;


	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
		gameSession = FindObjectOfType<GameSession>();
        gameSession.oldScore = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (gameSession.oldScore < gameSession.GetScore()) {
            gameSession.oldScore += 1;
            score.text = gameSession.oldScore.ToString();
        }
        
		//score.text = gameSession.GetScore().ToString();
	}
}
