using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

	private int score;
	private bool grounded;
	private bool groundedFirstTime = false;
	private PlayerController character;

	private void Awake() {
		SetUpSingleton();
	}

	private void Start() {
		character = FindObjectOfType<PlayerController>();
	}

	private void SetUpSingleton() {
		int numberGameSessions = FindObjectsOfType<GameSession>().Length;

		if (numberGameSessions > 1 ) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

	public int GetScore() {
        return score;
		}


	public void AddToScore(int scoreValue) {
		score += scoreValue;
	}

	public void ResetScore() {
        score = 0;
	}
}
