using UnityEngine;

public class PlayerLightsaber : MonoBehaviour {

    public bool active = true;

    public KeyCode key = KeyCode.L;
    public KeyCode attack = KeyCode.O;

    private LightsaberManager saber = null;

    void Start() {
        saber = GetComponentInChildren<LightsaberManager>();
    }

    void Update() {
        if(saber && active && Input.GetKeyDown(key))
            saber.active = !saber.active;
        
    }
}
