using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] Enemy[] enemyPrefabs;
	[SerializeField] bool spawning = true;
	[SerializeField] int minSpawnDelay = 1;
	[SerializeField] int maxSpawnDelay = 5;
	private int timeBetweenSpawns;

	// Use this for initialization
	IEnumerator Start() {

		while (spawning) {
			for (int i = 0; i < enemyPrefabs.Length; i++) {
				yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
				var lastIndex = enemyPrefabs.Length;
				var randomEnemy = Random.Range(0, lastIndex);
				SpawnEnemy(enemyPrefabs[randomEnemy]);
			}
		}
	}

	public void SpawnEnemy(Enemy enemy) {
		Instantiate(enemy, transform.position, transform.rotation);
	}
}
