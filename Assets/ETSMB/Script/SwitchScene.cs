using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		if (collider.CompareTag ("Player")) {
			Debug.Log ("Cambio scena");
			//SceneManager.LoadScene ("");
		}
	}
}
