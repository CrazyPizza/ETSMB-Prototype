using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public CheckpointController controller;
	public int CheckpointNumber; //Numero del checkpoint, deve corrispondere con la posizione di questo checkpoint
	//nella lista di checkpoint del CheckpointController!!

	void OnTriggerEnter(Collider collider) {

		//Se Jennir entra nel checkpoint, attivalo dicendo al controller il numero impostato in
		//CheckpointNumber
		//Il controllo viene fatto sul tag del collider di Jennir, PlayerBody, per evitare
		//che qualsiasi collider che entra nel checkpoint lo attivi

		if (collider.CompareTag("PlayerBody")){
			Debug.Log("entrato jennir");
			controller.setActiveCheckpoint(CheckpointNumber);
		}
	}

}
