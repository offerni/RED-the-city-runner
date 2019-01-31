using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    private SceneController sceneController;
    public bool gameIspaused = false;
    [SerializeField] GameObject pauseMenuUI;

    void Start() {
        sceneController = FindObjectOfType<SceneController>();
    }

    // Update is called once per frame

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIspaused = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIspaused = true;
    }
}
