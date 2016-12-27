using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {

		Debug.Log ("Checkpoint");
		PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
		PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
		PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;
		//GlobalControl.Instance.currentCheckpoint = gameObject;
		GlobalControl.Instance.SaveData ();

	}

}
