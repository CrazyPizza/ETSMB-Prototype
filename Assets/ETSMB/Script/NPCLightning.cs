using UnityEngine;
using System.Collections;

public class NPCLightning : _WeaponUseBehaviour {

	// Use this for initialization
	new void Start () {
        base.Start();
        LightningGenerator lg = GetComponentInChildren<LightningGenerator>();
        if(lg == null)
            enabled = false;
        else
            Fire = lg.Fire;
    }

}
