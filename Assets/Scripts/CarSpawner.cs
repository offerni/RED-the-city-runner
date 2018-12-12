using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
			for (int i = 0; i < carPrefabs.Length; i++) {
				yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
				var lastIndex = carPrefabs.Length;
				var randomCar = Random.Range(0, lastIndex);
				SpawnCar(carPrefabs[randomCar], randomCar);
			}
		}
	}

	public void SpawnCar(Car car, int carIndex) {
		if (carIndex == 2) {
			Instantiate(car, transform.position + (transform.up * 0.5f), transform.rotation);
		} else {
			Instantiate(car, transform.position, transform.rotation);
		}
		
	}
}
