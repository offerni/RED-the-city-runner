using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
	[Range(5, 50)]
	[SerializeField] int jumpForceY = 15;
	public bool grounded = false;
	[SerializeField] int jumpForceStartY = 16;
	[SerializeField] int jumpForceStartX = 6;	

	private Rigidbody2D myRigidbody;
	private BoxCollider2D myCollider;
	private AudioSource audioSource;
	private AudioSource audioSourceJump;
	private float audioVolume = 0.50f;

	/// <summary>
	/// listen the current eventsystem position, set it's position to mouse current position,
	/// populate the current position with raycasts and return true if is populated
	/// in other words, check if other UI element is touched
	/// </summary>
	/// <returns></returns>
	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();		
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}

	private void Start() {
		myRigidbody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<BoxCollider2D>();
		myRigidbody.velocity = new Vector2(jumpForceStartX, jumpForceStartY);
		audioSource = GetComponent<AudioSource>();
		audioSourceJump = audioSource;
		audioSourceJump.volume = audioVolume;
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
			if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject()) {
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForceY);
				audioSourceJump.Play();
			}
		}
	}
}
