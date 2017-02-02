using UnityEngine;
using System.Collections;

public class BridgeCrash : MonoBehaviour {

    private StatsInfo si;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "PlayerBody") {
            si = other.gameObject.GetComponentInParent<StatsInfo>();
            int crash = Random.Range(1,20);
            if (si.DEX < crash) {
                si.HP = 0;
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
