using UnityEngine;
using System.Collections;

public class PlayerGrenadeLauncer : MonoBehaviour {

	public bool active = true;
	public KeyCode key = KeyCode.P;

	public int granate = 3;

	private ParabolicFireGenerator pfg = null;

	void Start () {
		pfg = GetComponentInChildren<ParabolicFireGenerator> ();
	}
	
	void Update () {
		
		if (pfg && active && Input.GetKeyDown (key)) {
			
			Debug.Log ("Granate disponibili: " + granate);

			if (granate > 0) {

				pfg.Fire (null);
				granate = granate - 1;
				Debug.Log ("Rimangono ancora " + granate + " granate");
			
			} else {

				Debug.Log ("Granate finite");
				active = false;
			
			}
		}
	}

	public void addGranade(int i) {
		granate += i;
	}
}
