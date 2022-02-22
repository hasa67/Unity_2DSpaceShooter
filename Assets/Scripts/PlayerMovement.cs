using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;
	public float rotSpeed = 180f;

	float shipRadius = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
		transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotSpeed * Time.deltaTime);

		Vector3 pos = transform.position;

		if (transform.position.y > Camera.main.orthographicSize - shipRadius)
        {
			pos.y = Camera.main.orthographicSize - shipRadius;
			transform.position = pos;
		}
		if (transform.position.y < -Camera.main.orthographicSize + shipRadius)
		{
			pos.y = -Camera.main.orthographicSize + shipRadius;
			transform.position = pos;
		}

		float widthOrtho = (float)Screen.width / (float)Screen.height * Camera.main.orthographicSize;
		if (transform.position.x > widthOrtho - shipRadius)
		{
			pos.x = widthOrtho - shipRadius;
			transform.position = pos;
		}
		if (transform.position.x < -widthOrtho + shipRadius)
		{
			pos.x = -widthOrtho + shipRadius;
			transform.position = pos;
		}
	}
}
