using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

	private float score;
	private float scoreCountVelocity = 20;
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
			return (int)score;
		}


	public void AddToScore(float scoreValue) {

		grounded = character.grounded;
		if (grounded) {
			groundedFirstTime = true;
		}
		if (groundedFirstTime) {
			score += scoreValue * scoreCountVelocity * Time.deltaTime;
		}
	}

	public void ResetScore() {
		Destroy(gameObject);
	}
}
