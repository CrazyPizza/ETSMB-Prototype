﻿using UnityEngine;
using System.Collections;

public class ParabolicFireGenerator : MonoBehaviour {

	public Transform ammo = null;
	[Range(0.01f, 30f)] public float force = 10f;
	[Range(0.00f, 90f)] public float angle = 45f;

    public StatsInfo stats;

	public void Fire(Transform t) {
		if (ammo != null) {
            Debug.Log(t);
			Transform tt = (Transform) Instantiate (ammo, transform.position, transform.parent.rotation);
            tt.GetComponent<Rigidbody>().velocity = (Quaternion.Euler(-angle,0f,0f) * transform.parent.forward) * force;
            tt.GetComponent<DamageProvider>().attacker = stats;
		}
	}

}
