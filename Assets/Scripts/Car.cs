using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	[Range(1,10)]
	[SerializeField] float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}
}
