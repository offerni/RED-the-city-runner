using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	private AudioSource musicPlayer;
	[SerializeField] float bgmVolume = 0.80f;

	/// <summary>
	/// Setting up singleton, if there's more than one instance of this object, it'll be destroyed.
	/// </summary>
	private void Awake() {
		musicPlayer = GetComponent<AudioSource>();
		SetMusicVolume();
		DontDestroyOnLoad(this);
		if(FindObjectsOfType<MusicPlayer>().Length > 1) {
			Destroy(gameObject);
		}
	}

	private void SetMusicVolume() {
		musicPlayer.volume = bgmVolume;
	}

	public static void MuteSounds() {
        AudioListener.pause = !AudioListener.pause;
	}

	public void RestartMusic() {
		musicPlayer.Stop();
		musicPlayer.Play();
	}
}
