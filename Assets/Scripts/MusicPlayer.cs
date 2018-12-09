using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	private AudioSource musicPlayer;
	private float bgmVolume = 0.80f;
	private bool musicOn;
	private PlayerController character;

	private void Awake() {
		musicPlayer = GetComponent<AudioSource>();
		DontDestroyOnLoad(musicPlayer);
		SetMusicVolume();
	}

	private void SetMusicVolume() {
		musicPlayer.volume = bgmVolume;
	}

	public void ToggleMusic() {
		character = FindObjectOfType<PlayerController>();
		var jumpSound = character.GetComponent<AudioSource>();
		jumpSound.mute = !jumpSound.mute;
		musicPlayer.mute = !musicPlayer.mute;
	}

	public void RestartMusic() {
		musicPlayer.Stop();
		musicPlayer.Play();
	}

	public void PauseMusic() {

	}
}
