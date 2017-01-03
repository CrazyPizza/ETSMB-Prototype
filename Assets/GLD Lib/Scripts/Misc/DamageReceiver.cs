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
			i = i * (attacker.THAC0 - si.AC);
			si.HP = si.HP - i;
			if (si.HP <= 0)
				Destroy (si.gameObject);
		}
		/*if (active) {
			// Dass difende
			if (attacker.tag == "Player") {
				i = i * (si.THAC0 - PlayerState.Instance.localPlayerData.AC);
				PlayerState.Instance.localPlayerData.HP = PlayerState.Instance.localPlayerData.HP - i;
			} else {
				i = i * (PlayerState.Instance.localPlayerData.THAC0 - si.AC);
				si.HP = si.HP - i;
				if (si.HP <= 0)
					Destroy (si.gameObject);
			}
		}*/
	}
}