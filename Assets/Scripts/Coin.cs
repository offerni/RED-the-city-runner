using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] AudioClip coinSFX;
    [SerializeField] [Range(0, 1)] float coinSFXVolume = 0.75f;
    [SerializeField] GameObject coinVFX;

    private int coinSpeed = 5;
    private int coinValue = 20;
    private GameSession gameSession;

    private void Start() {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update() {
        transform.Translate(Vector2.left * coinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 8) {
            StopAllCoroutines();
            StartCoroutine(gameSession.AddToScore(coinValue));
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position, coinSFXVolume);
            var tempVFX = Instantiate(coinVFX, transform.position, transform.rotation);
            Destroy(tempVFX, 1);
            Destroy(gameObject);
        } 
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
