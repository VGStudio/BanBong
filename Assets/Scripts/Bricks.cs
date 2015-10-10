﻿using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;

	void OnCollisionEnter(Collision other){
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBricks ();
		//GM.instance.IncreasePaddle ();
		Destroy (gameObject);
	}
}
