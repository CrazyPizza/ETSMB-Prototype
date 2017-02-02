using UnityEngine;
using System.Collections;

public class LightsaberManager : MonoBehaviour {

	public bool active = false;
	private bool previous = false;
	public Transform currentTarget=null;
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

    public void attack() {
		if(currentTarget != null){
			Debug.Log("SONO: "+currentTarget.gameObject.name);
			dp.ProvideDamage(currentTarget);
		}else{
			Debug.Log("Nessun Target");
		}
    }

	private void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag == "NPC Enemy"){
			currentTarget=other.gameObject.transform;
			Debug.Log(currentTarget.name);
		}
	}

	private void OnTriggerExit(Collider other){
		currentTarget=null;
	}
}
