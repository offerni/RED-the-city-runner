using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

	[SerializeField] float moveSpeed = 2f;
	[SerializeField] int enemyDamage = 1;
	[SerializeField] PlayerController character;

	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}

	/// <summary>
	/// function to destroy the object after leave the player scenario
	/// </summary>
	/// <param name="collision"></param>
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.layer == 13) {
			Destroy(gameObject);
		} if (collision.gameObject.layer == 8) {
			HitCharacter(1);
			if (character.life < enemyDamage) {
				var sceneController = FindObjectOfType<SceneController>();
				sceneController.GameOver();
			}
		}
	}

	private void HitCharacter(int dmg) {
		Destroy(GameObject.Find("Heart_" + character.life));
		character.life -= dmg;
	}
}
