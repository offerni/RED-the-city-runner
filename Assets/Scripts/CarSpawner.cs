using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {
	[SerializeField] Car[] carPrefabs;
	[SerializeField] bool spawning = true;

	private int minSpawnDelay = 3;
	private int maxSpawnDelay = 10;
	private int timeBetweenSpawns;

	// Use this for initialization
	IEnumerator Start () {

		while(spawning) {
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
			SpawnCar();
		}
		
	}

	public void SpawnCar() {
		foreach (var car in carPrefabs) {
			Instantiate(car, transform.position, transform.rotation);
		}
	}
}
