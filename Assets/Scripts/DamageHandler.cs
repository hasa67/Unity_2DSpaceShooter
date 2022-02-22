using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    public int health = 1;
	public float invulnDuration = 0f;
	float invulnTimer = 0f;
    int correctLayer;
	SpriteRenderer sr;
	float invulnFlashInterval = 0.1f;

    void Start()
    {
		correctLayer = gameObject.layer;
		if (sr == null) {
			sr = GetComponent<SpriteRenderer> ();
			if (sr == null) {
				sr = GetComponentInChildren<SpriteRenderer> ();
			}
		}
    }

    void Update()
    {
		if (invulnTimer > 0) {
			invulnTimer -= Time.deltaTime;
		}

		if (invulnTimer <= 0) {
			gameObject.layer = correctLayer;
			sr.enabled = true;
		} else {
			invulnFlashInterval -= Time.deltaTime;
			if (invulnFlashInterval <= 0) {
				sr.enabled = !sr.enabled;
				invulnFlashInterval = 0.1f;
			}
		}

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D()
    {
        health--;
		invulnTimer = invulnDuration;
        gameObject.layer = 10;
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
