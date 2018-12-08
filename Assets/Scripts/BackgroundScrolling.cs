using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundScrolling : MonoBehaviour {

	private BoxCollider2D myCollider;
	private PlayerController character;
	[SerializeField] bool grounded;
	private bool groundedFirstTime = false;

    // For the background Road
    private Material material;
    private Vector2 offset;

    public float scrollingVelocity;  

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        
    }

    // Use this for initialization
    void Start () {
		character = FindObjectOfType<PlayerController>();
		offset = new Vector2(scrollingVelocity, 0);
	}
	
	// Update is called once per frame
	void Update () {
		grounded = character.grounded;
		if(grounded) {
			groundedFirstTime = true;
		} if (groundedFirstTime) {
			material.mainTextureOffset -= offset * Time.deltaTime;
		}
	}
}
