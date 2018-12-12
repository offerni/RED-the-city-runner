using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	[Range(0, 15)]
	[SerializeField] float speed = 5f;

	private PlayerController character;
	private EdgeCollider2D impactArea;

	
	private Rigidbody2D characterRigidBody2D;

	private void Start() {
		character = FindObjectOfType<PlayerController>();
		characterRigidBody2D = character.GetComponent<Rigidbody2D>();
		impactArea = GetComponentInChildren<EdgeCollider2D>();

	}
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.layer == 13) {
			Destroy(gameObject);
		}
	}

}
