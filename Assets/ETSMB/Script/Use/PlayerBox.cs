using UnityEngine;
using System.Collections;

public class PlayerBox : MonoBehaviour {

	public bool active = true;
	public KeyCode key = KeyCode.E;

	float distance = 2F;
	RaycastHit obj;
	BoxManager boxManager;

	void Update () {
		if (active && Input.GetKeyDown (key) && Physics.Raycast (this.transform.position, this.transform.forward, out obj, distance)) {
			if (obj.collider.gameObject.tag == "Box") {
				boxManager = obj.collider.gameObject.GetComponent<BoxManager> ();
				boxManager.Open(obj.collider.gameObject);
				Destroy (obj.collider.gameObject);
			}
		}

	}
}
