using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

	private int score;
	private bool grounded;
	private bool groundedFirstTime = false;
	private PlayerController character;
    public int oldScore;

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


	public IEnumerator AddToScore(int scoreValue) {
        var futureScore = score + scoreValue;
        while(score < futureScore) {
            score += 1;
        }
        yield return null;
    }

	public void ResetScore() {
        score = 0;
	}
}
