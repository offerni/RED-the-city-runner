using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	private int currentScene;

	public void LoadScene() {
		currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene + 1);
	}
}
