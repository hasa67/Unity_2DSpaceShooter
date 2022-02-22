using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject EnemyPrefab;
	float enemyRate = 5f;
	float nextEnemy = 1f;
	float spawnDistance = 20f;

	void Start () {
		EnemySpawn ();
	}

	void Update () {
		nextEnemy -= Time.deltaTime;
		if (nextEnemy <= 0) {
			EnemySpawn ();
		}
	}

	void EnemySpawn(){
		Vector3 offset = Random.onUnitSphere;
		offset.z = 0;
		offset = offset.normalized * spawnDistance;

		Instantiate (EnemyPrefab, offset, Quaternion.Euler(0, 0, Random.Range(0,361)));
		nextEnemy = enemyRate;
		enemyRate *= 0.9f;
		if (enemyRate <= 2) {
			enemyRate = 2f;
		}
	}
}
