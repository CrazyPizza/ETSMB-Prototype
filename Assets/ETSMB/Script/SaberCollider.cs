using UnityEngine;
using System.Collections;

public class SaberCollider : MonoBehaviour {



    private DamageProvider dp;
    //public StatsInfo si;

	// Use this for initialization
	void Start () {
        //dp = GetComponent<DamageProvider>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.tag);
    }


}

