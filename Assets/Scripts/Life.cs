using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
	[SerializeField] GameObject heart;
	private GameObject clone;
    private Life lifeCanvas;

	[SerializeField] int life;
    private int numberOfHearts;
    

    public int GetLife() {
		return life;
	}

	public void SetLife(int life) {
		this.life = life;
	}

    public void ShowLifeHearts() {
        lifeCanvas = GetComponentInParent<Life>();
        for (numberOfHearts = 1; numberOfHearts <= GetLife(); numberOfHearts++) {
            clone = Instantiate(heart, lifeCanvas.transform);
            clone.transform.position = new Vector3(transform.position.x * numberOfHearts, transform.position.y);
            clone.name = "Heart_" + numberOfHearts;
        }
    }
}
