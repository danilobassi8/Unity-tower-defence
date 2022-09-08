using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemiesInSameWave = 0.3f;

    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update() {
        countdown -= Time.deltaTime;
        if (countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
    }

    IEnumerator SpawnWave() {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemiesInSameWave);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
