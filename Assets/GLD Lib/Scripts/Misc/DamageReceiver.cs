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
			Debug.Log ("Valore atteso dado: " + i);
			float probabilityHit = (20.0F - ((attacker.THAC0 - si.AC) - 1)) / 20.0F;
			Debug.Log("Hit: " + probabilityHit);
			float dmg = i * probabilityHit;
			Debug.Log ("Danno finale: " + dmg);
			si.HP = si.HP - dmg;

			if (si.HP <= 0) {
				if (si.name == "Mercenary Brute") {
                    Debug.Log("Mercenario stordito");
                    StartCoroutine(MercenaryStun(si.gameObject));
                } else {
					Destroy (si.gameObject);
				}
			}

		}
	}

    IEnumerator MercenaryStun(GameObject obj) {
        obj.GetComponent<NPCBlaster>().active = false;
        yield return new WaitForSeconds(5);
        si.HP = 30;
        obj.GetComponent<NPCBlaster>().active = true;
        Debug.Log("Mecenario ripreso");
    }

}