using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1.0f;

	private Vector3 playerPos = new Vector3(0, 9.5f, 0);


	// Update is called once per frame
	void FixedUpdate () {
		//Input.GetButtonDown("Fire1")
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0);
		transform.position = playerPos;
	}
}
