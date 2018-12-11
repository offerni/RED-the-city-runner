using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	private PlayerController character;
	private EdgeCollider2D impactArea;
	private int xPush = -11;
	private int yPush = 15;
	private int speedPush = 35;



	[Range(1,10)]
	[SerializeField] float speed = 5f;
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
	/// <summary>
	/// Remove all the constraints if the car impact area touches the character.
	/// </summary>
	/// <param name="collision"></param>
	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.layer == 8) {
			characterRigidBody2D.constraints = RigidbodyConstraints2D.None;
			characterRigidBody2D.velocity = new Vector2(xPush, yPush) * speedPush * Time.deltaTime;
		}
	}


}
