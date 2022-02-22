using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

	float cooldownTimer = 0f;
	public float fireDelay = 0.25f;
	public GameObject bullet;
	public GameObject gunPosition;
	int bulletLayer;

	void Start(){
		bulletLayer = gameObject.layer;
	}

	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (Input.GetButton("Fire1") && cooldownTimer <= 0)
		{
			cooldownTimer = fireDelay;
			GameObject bulletGO = (GameObject)Instantiate (bullet, gunPosition.transform.position, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}
