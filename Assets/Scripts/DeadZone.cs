using UnityEngine;
using System.Collections;

public class De : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		GM.instance.LoseLife ();
	}
}
