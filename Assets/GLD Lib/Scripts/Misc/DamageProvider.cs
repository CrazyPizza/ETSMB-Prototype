using UnityEngine;
using System.Collections;

public class DamageProvider : MonoBehaviour {

	public bool active = true;

	//numero di dadi
	//public int multiplicity = 1;
	//public int dice = 6;
	//public int bonus = 0;
	public StatsInfo attacker;

	public void ProvideDamage(Transform t) {
		if (active) {
			DamageReceiver dr = t.root.GetComponentInChildren<DamageReceiver> ();
			if (dr != null) {
				int dmg = 0;
				for (int i = 0; i < attacker.Mutiplier; i += 1)
					dmg += Random.Range (1, attacker.Damage);
				dmg += attacker.Bonus;
				dr.ReceiveDamage (attacker, dmg);
			}
		}
	}
}