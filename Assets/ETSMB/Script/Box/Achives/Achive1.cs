using UnityEngine;
using System.Collections;

public class Achive1 : MonoBehaviour {

	public void GiveAchive(bool fail) {
		
		GameObject player = GameObject.FindWithTag ("Player");
		Debug.Log ("HP prima: " + player.GetComponentInChildren<StatsInfo> ().HP);
		if (fail == false)
			player.GetComponentInChildren<StatsInfo> ().HP += (player.GetComponentInChildren<StatsInfo> ().HP * 0.2F);
		else
			player.GetComponentInChildren<StatsInfo> ().HP -= (player.GetComponentInChildren<StatsInfo> ().HP * 0.2F);
		Debug.Log ("HP dopo: " + player.GetComponentInChildren<StatsInfo> ().HP);

	}
}
