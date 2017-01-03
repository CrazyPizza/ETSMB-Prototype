using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageReceiver : MonoBehaviour {

	public bool active = true;

	private StatsInfo si;

	void Start() {
		si = GetComponentInChildren<StatsInfo> ();
	}

	public void ReceiveDamage(StatsInfo attacker, int i) {
		if (active && si != null) {
			Debug.Log ("Attacker: " + attacker);
			Debug.Log ("Thac0: " + attacker.THAC0);
			Debug.Log ("AC: " + si.AC);
			i = i * (attacker.THAC0 - si.AC);
			Debug.Log ("i: " + i);
			si.HP = si.HP - i;
			//if (si.HP <= 0)
			//	Destroy (si.gameObject);
		}
	}
}