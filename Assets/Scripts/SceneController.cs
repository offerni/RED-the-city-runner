using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour {

	private int currentScene;
	private int numberOfScenes;
	private bool musicOn;
	private MusicPlayer musicPlayer;

	private void Awake() {
		
	}

	private void Start() {

		//fix the bug that was keeping the game paused after restart
		if(Mathf.Approximately(Time.timeScale, 0.0f)) {
			Time.timeScale = 1.0f;
		}
	}
	
	/// <summary>
	/// Check if the next scene index is less or equal to the total of scenes, if true, load next scene.
	/// </summary>
	public void LoadNextScene() {
		numberOfScenes = SceneManager.sceneCountInBuildSettings;
		currentScene = SceneManager.GetActiveScene().buildIndex;

		if (currentScene + 1 < numberOfScenes) {
			SceneManager.LoadScene(currentScene + 1);
		}
	}

	public void LoadScene(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}

	public void RestartGame() {
		currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene);
	}
	/// <summary>
	/// Compares if the timescale is equal to 0, if true: means that the game is paused, then Run.
	/// If the timescale is different than 0, means that the game us running, then Pause.
	/// 
	/// </summary>
	public void PauseGame() {
		Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;

		currentScene = SceneManager.GetActiveScene().buildIndex;
	}

	public void ToggleMusicButton() {
		musicPlayer = FindObjectOfType<MusicPlayer>();
		musicPlayer.ToggleMusic();
	}

	public void Quit() {
		Application.Quit();
	}
}
