using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update() {
        countdown -= Time.deltaTime;
        if (countdown <= 0) {
            SpawnWave();
        }
    }

    void SpawnWave() {
        for (int i = 0; i < waveIndex++; i++) {
            Debug.Log("Spawning enemy");
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
