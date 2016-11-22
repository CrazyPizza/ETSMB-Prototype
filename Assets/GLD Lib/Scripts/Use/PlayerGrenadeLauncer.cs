using UnityEngine;
using System.Collections;

public class PlayerGrenadeLauncer : MonoBehaviour {

	public bool active = true;
	public KeyCode key = KeyCode.Q;

	private ParabolicFireGenerator pfg = null;

	void Start () {
		pfg = GetComponentInChildren<ParabolicFireGenerator> ();
	}
	
	void Update () {
		if (pfg && active && Input.GetKeyDown (key)) {
            Debug.Log("Sparato");
			pfg.Fire (null);
		}
	}
}
