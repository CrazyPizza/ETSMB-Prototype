using UnityEngine;
using System.Collections;

public class LightsaberManager : MonoBehaviour {

	public bool active = false;
	private bool previous = false;

	private LineRenderer line;
	private CapsuleCollider cc;
	private Light l;

    private DamageProvider dp;

	void Start() {
		line = GetComponentInChildren<LineRenderer> ();
		cc = GetComponentInChildren<CapsuleCollider> ();
		l = GetComponentInChildren<Light> ();
        dp = GetComponentInChildren<DamageProvider>();
	}

    void Update() {
        if(previous != active) {
            if(line != null) line.enabled = active;
            if(cc != null) cc.enabled = active;
            if(l != null) l.enabled = active;
            previous = active;
        }
    }

    public void attack(Transform t) {
        dp.ProvideDamage(t);
    }
}
