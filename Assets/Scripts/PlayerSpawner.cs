using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;
	float respawnTimer;

	int numLives = 2;

	void Start () {
		PlayerSpawn ();
	}

	void Update () {
		if (playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;
			if(respawnTimer <= 0){
				numLives--;
				PlayerSpawn ();
			}
		}
	}

	void PlayerSpawn(){
		respawnTimer = 1f;
		playerInstance = (GameObject)Instantiate (playerPrefab, transform.position, Quaternion.identity);
	}

	void OnGUI(){
		if (numLives > 0 || playerInstance != null) {
			GUI.Label (new Rect (0, 0, 100, 50), "Lives Left: " + numLives);
		} else {
			GUI.Label (new Rect (Screen.width / 2 - 75, Screen.height / 2 - 25, 150, 50), ">> GAME OVER <<");
		}
	}
}
