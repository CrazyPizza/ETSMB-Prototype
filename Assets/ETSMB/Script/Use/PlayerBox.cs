using UnityEngine;
using System.Collections;

public class PlayerBox : MonoBehaviour {

	public bool active = true;
	public KeyCode key = KeyCode.E;

	private bool guiShow = false;
	float distance = 2F;
	RaycastHit obj;
	BoxManager boxManager;

	void Update () {
		if (active) {
			if (Physics.Raycast (this.transform.position, this.transform.forward, out obj, distance) && obj.collider.gameObject.tag == "Box") {
				guiShow = true;
				if (Input.GetKeyDown (key)) {
					boxManager = obj.collider.gameObject.GetComponent<BoxManager> ();
					boxManager.Open (obj.collider.gameObject);
					Destroy (obj.collider.gameObject);
					guiShow = false;
				}
			} else {
				guiShow = false;
			}
		}
	}
		
	void OnGUI() {
		if (guiShow == true) {
			GUI.contentColor = Color.red;
			GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.5f, 100f, 20f), "Press E button");
		}
	}	
}
