using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	private AudioSource musicPlayer;
	private float bgmVolume = 0.80f;
	private bool musicOn;

	private void Awake() {
		musicPlayer = GetComponent<AudioSource>();
		DontDestroyOnLoad(musicPlayer);
		SetMusicVolume();
	}

	private void SetMusicVolume() {
		musicPlayer.volume = bgmVolume;
	}

	public void ToggleMusic() {
		musicPlayer.mute = !musicPlayer.mute;
	}
}
