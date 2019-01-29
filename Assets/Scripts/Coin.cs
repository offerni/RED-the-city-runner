using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] AudioClip coinSFX;
    [SerializeField] [Range(0, 1)] float coinSFXVolume = 0.75f;

    private int coinSpeed = 5;
    private GameSession gameSession;

    private void Start() {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update() {
        transform.Translate(Vector2.left * coinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 8) {
            gameSession.AddToScore(20);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position, coinSFXVolume);
            Destroy(gameObject);
        } 
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
