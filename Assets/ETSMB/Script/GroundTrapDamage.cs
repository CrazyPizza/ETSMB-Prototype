using UnityEngine;
using System.Collections;

public class GroundTrapDamage : MonoBehaviour {

    public bool Disarm(Transform t) {

        Debug.Log("Mina");
        StatsInfo si = t.root.GetComponentInChildren<StatsInfo>();
        int disarm = Random.Range(1,20);
        int dmg = Random.Range(1,4);
        Debug.Log(si.INT);
        Debug.Log(disarm);
        Debug.Log(dmg);
        if(si.INT >= disarm) {
            Debug.Log("Mina disinnescata");
            return true;
        } else {
            si.HP -= dmg;
            return false;
        }
    }
}
