using UnityEngine;
using System.Collections;

public class PlayerLightSaber : MonoBehaviour {

    public bool active = true;
    public KeyCode key = KeyCode.L;

    public KeyCode attack = KeyCode.O;
    RaycastHit obj;

    private LightsaberManager saber = null;

    void Start() {
        saber = GetComponentInChildren<LightsaberManager>();
    }

    void Update() {
		if (saber && active && Input.GetKeyDown(key)){
			UIController.UI.setCurrentWeaponGUI("Lightsaber");
			saber.active = !saber.active;
		}
        if (saber && active) {
			if (Input.GetKeyDown(attack)) {
				Debug.Log("ATTACCO");
				saber.attack();
			}



        }
    }

}