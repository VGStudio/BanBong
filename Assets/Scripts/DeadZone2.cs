using UnityEngine;
using System.Collections;

public class DeadZone2 : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		GM.instance.LoseLife ();
	}
}
