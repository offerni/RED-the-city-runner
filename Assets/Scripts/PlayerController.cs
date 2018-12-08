using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
	[SerializeField] GameObject character;
	[Range(5, 50)]
	[SerializeField] int jumpForceY = 15;
	public bool grounded = false;
	[SerializeField] int jumpForceStartY = 16;
	[SerializeField] int jumpForceStartX = 6;	

	private Rigidbody2D myRigidbody;
	private BoxCollider2D myCollider;


	private void Start() {
		myRigidbody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<BoxCollider2D>();
		myRigidbody.velocity = new Vector2(jumpForceStartX, jumpForceStartY);
	}

	// Update is called once per frame
	private void Update () {
			Jump();
	}

	/// <summary>
	/// This function check if the character is on the ground and jump if it's true.
	/// </summary>
	public void Jump() {
		grounded = Physics2D.IsTouchingLayers(myCollider);
		if (grounded) {
			if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForceY);
			}
		}
	}
}
