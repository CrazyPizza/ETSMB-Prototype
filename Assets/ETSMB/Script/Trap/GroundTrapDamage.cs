using UnityEngine;
using System.Collections;

public class GroundTrapDamage : MonoBehaviour {

    public bool Disarm(Transform t) {
   
        StatsInfo si = t.root.GetComponentInChildren<StatsInfo>();
        int disarm = Random.Range(1,20);
        int dmg = Random.Range(1,4);
        if(si.INT >= disarm) {
            return true;
        } else {
            si.HP -= dmg;
            return false;
        }
    }
}
