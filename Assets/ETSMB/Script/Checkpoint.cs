using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {

		Debug.Log ("Checkpoint");
		GlobalControl.Instance.currentCheckpoint = gameObject;
		GlobalControl.Instance.SaveData ();
	}

}
