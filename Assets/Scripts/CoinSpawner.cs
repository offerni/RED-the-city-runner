using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    
    [SerializeField] Coin coin;
    [SerializeField] bool spawning;
    private int coinsToSpawn;
    private int coinsCounter;
    [SerializeField] float timeBetweenCoins;

    [SerializeField] int mintimeBetweenSpawns;
    [SerializeField] int maxtimeBetweenSpawns;
    private int timeBetweenSpawns;
    

    public void Start() {
        StopAllCoroutines();
        StartCoroutine(SpawnCoins());
    }


    /// <summary>
    /// Randomize the number of coins and the time between coins spawns
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnCoins() {
        while (spawning) {
            coinsCounter = 0;
            timeBetweenSpawns = Random.Range(mintimeBetweenSpawns, maxtimeBetweenSpawns);
            coinsToSpawn = Random.Range(3, 8);
            while (coinsCounter < coinsToSpawn) {
                Instantiate(coin, transform.position, transform.rotation);
                yield return new WaitForSeconds(timeBetweenCoins);
                coinsCounter++;
            }
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
            
    }
}
