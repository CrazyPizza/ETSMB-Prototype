using UnityEngine;
using System.Collections;

public class PlayerLightSaber : MonoBehaviour {

    public bool active = true;
    public KeyCode key = KeyCode.L;

    public KeyCode attack = KeyCode.O;
    float distance = 2f;
    RaycastHit obj;

    private LightsaberManager saber = null;

    void Start() {
        saber = GetComponentInChildren<LightsaberManager>();
    }

    void Update() {
        if (saber && active && Input.GetKeyDown(key))
            saber.active = !saber.active;
        if (saber && active) {
            if (Input.GetKeyDown(attack) && Physics.Raycast(this.transform.position, this.transform.forward, out obj, distance) && obj.collider.gameObject.tag == "NPC Enemy") {
                saber.attack(obj.collider.gameObject.transform);
                Debug.Log(obj.collider.gameObject.transform);
            }
        }
    }
}