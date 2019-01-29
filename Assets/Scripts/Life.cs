using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
	[SerializeField] GameObject heart;
	private GameObject clone;

	private int life;

	public int GetLife() {
		return life;
	}

	public void SetLife(int life) {
		this.life = life;
	}

	private int numberOfHearts;

	private void Start() {
		for (numberOfHearts = 1; numberOfHearts <= GetLife(); numberOfHearts++) {
			clone = Instantiate(heart, transform.position, transform.rotation);
			clone.transform.position += Vector3.right * numberOfHearts;
			clone.name = "Heart_" + numberOfHearts;
		}
	}
}
