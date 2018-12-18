using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
	[SerializeField] GameObject heart;
	PlayerController character;
	private GameObject clone;

	private int numberOfHearts;

	private void Start() {
		character = FindObjectOfType<PlayerController>();
		for (numberOfHearts = 1; numberOfHearts <= character.life; numberOfHearts++) {
			clone = Instantiate(heart, transform.position, transform.rotation);
			clone.transform.position += Vector3.right * numberOfHearts;
			clone.name = "Heart_" + numberOfHearts;
		}
	}
}
