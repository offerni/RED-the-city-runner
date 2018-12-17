using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

	[SerializeField] float moveSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}

	/// <summary>
	/// function to add damage to the player on collision
	/// </summary>
	/// <param name="collision"></param>
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.layer == 8) {
			print("Damage added");
		} else {
			Destroy(gameObject);
		}
		
	}
}
