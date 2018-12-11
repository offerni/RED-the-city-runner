using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {
	[SerializeField] Car[] carPrefabs;
	[SerializeField] bool spawning = true;

	[SerializeField] int minSpawnDelay = 1;
	[SerializeField] int maxSpawnDelay = 5;
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
