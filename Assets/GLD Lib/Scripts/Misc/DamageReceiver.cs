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
			float probabilityHit = (20.0F - ((attacker.THAC0 - si.AC) - 1)) / 20.0F;
			float dmg = i * probabilityHit;
			si.HP = si.HP - dmg;
			if (si.HP <= 0) {
                if(si.name == "Player" || si.name == "Xenus") {
                    // ci pensa il checkpoint controller
                } else if(si.name == "Mercenary Brute") {
                    StartCoroutine(MercenaryStun(si.gameObject));
				} else if(si.name== "Noirah Nah") {
					si.HP = 5;
				} else {
					Destroy(si.gameObject);
				}
			} 
        }
	}

    IEnumerator MercenaryStun(GameObject obj) {
        obj.GetComponent<NPCBlaster>().active = false;
        yield return new WaitForSeconds(5);
        si.HP = 30;
        obj.GetComponent<NPCBlaster>().active = true;
    }
}