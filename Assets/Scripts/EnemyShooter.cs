using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

	float cooldownTimer = 0f;
	public float fireDelay = 0.75f;
	public GameObject bullet;
	public GameObject gunPosition;
	int bulletLayer;

	Transform player;

	void Start(){
		bulletLayer = gameObject.layer;
	}

	void Update () {
		
		if (player == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("Player");

			if (go != null) {
				player = go.transform;
			}
		}

		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 2)
		{
			cooldownTimer = fireDelay;
			GameObject bulletGO = (GameObject)Instantiate (bullet, gunPosition.transform.position, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}
