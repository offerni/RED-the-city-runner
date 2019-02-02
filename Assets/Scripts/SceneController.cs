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
	public bool gamePaused = false;
	private int collisionCount = 0;
	GameSession gameSession;
    private PauseMenu pauseMenu;

	private void Start() {
        

        //fix the bug that was keeping the game paused after restart
        if (Mathf.Approximately(Time.timeScale, 0.0f)) {
			Time.timeScale = 1.0f;
            musicPlayer = FindObjectOfType<MusicPlayer>();
            var backgroundMusic = musicPlayer.GetComponent<AudioSource>();
            backgroundMusic.volume = 0.8f;
            //backgroundMusic.Stop();
            //backgroundMusic.Play();
        }
		numberOfScenes = SceneManager.sceneCountInBuildSettings;
		currentScene = SceneManager.GetActiveScene().buildIndex;
	}

    /// <summary>
    /// Check if the next scene index is less or equal to the total of scenes, if true, load next scene.
    /// </summary>
    public void LoadNextScene() {

		if (currentScene + 1 < numberOfScenes) {
			SceneManager.LoadScene(currentScene + 1);
		}
	}

	public void LoadScene(int sceneIndex) {
        if (sceneIndex == 0 && FindObjectsOfType<GameSession>().Length > 0) {
            FindObjectOfType<GameSession>().ResetScore();
        }
        SceneManager.LoadScene(sceneIndex);
    }

	public void RestartGame() {
		var mainGameSceneIndex = 2;
		musicPlayer = FindObjectOfType<MusicPlayer>();
		//musicPlayer.RestartMusic();
		//currentScene = SceneManager.GetActiveScene().buildIndex;
		LoadScene(mainGameSceneIndex);
		gameSession = FindObjectOfType<GameSession>();
		gameSession.ResetScore();

	}
	/// <summary>
	/// Compares if the timescale is equal to 0, if true: Unpause the Game and Music. And vice versa.
	/// 
	/// </summary>
	public void PauseGame() {
        pauseMenu = FindObjectOfType<PauseMenu>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
		var backgroundMusic = musicPlayer.GetComponent<AudioSource>();

		if (pauseMenu.gameIspaused) {
            pauseMenu.Resume();
            backgroundMusic.volume = 0.8f;
            
        } else {
            pauseMenu.Pause();
            backgroundMusic.volume = 0.3f;
        }
	}

	public void GameOver() {
		musicPlayer = FindObjectOfType<MusicPlayer>();
		LoadScene(numberOfScenes - 2);
	}

	public void ToggleMusicButton() {
		musicPlayer = FindObjectOfType<MusicPlayer>();
		MusicPlayer.MuteSounds();
	}

	public void Quit() {
		Application.Quit();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		var character = FindObjectOfType<PlayerController>();
		if(collision.gameObject.layer == 8) {
			character.grounded = false;
			collisionCount++;
			if (collisionCount > 1) {
				GameOver();
			}
		}
	}
}
