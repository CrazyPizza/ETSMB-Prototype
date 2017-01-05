using UnityEngine;
using System.Collections;

public class PlayerBox : MonoBehaviour {

	public bool active = true;
	public KeyCode key = KeyCode.E;

	float distance = 2F;
	RaycastHit obj;
	BoxManager box;

	void Update () {
		if (active && Input.GetKeyDown (key) && Physics.Raycast (this.transform.position, this.transform.forward, out obj, distance)) {
			if (obj.collider.gameObject.tag == "Box") {
				box = obj.collider.gameObject.GetComponent<BoxManager> ();
				box.Open();
				Destroy (obj.collider.gameObject);
			}
		}

	}
}
