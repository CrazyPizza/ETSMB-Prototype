using UnityEngine;
using System.Collections;

public class Award {

	public void GiveAward1(bool fail) {
		
		GameObject player = GameObject.FindWithTag ("Player");
		Debug.Log ("HP prima: " + player.GetComponentInChildren<StatsInfo> ().HP);
		if (fail == false)
			player.GetComponentInChildren<StatsInfo> ().HP += (player.GetComponentInChildren<StatsInfo> ().HP * 0.2F);
		else
			player.GetComponentInChildren<StatsInfo> ().HP -= (player.GetComponentInChildren<StatsInfo> ().HP * 0.2F);
		Debug.Log ("HP dopo: " + player.GetComponentInChildren<StatsInfo> ().HP);

	}

	public void GiveAward2(bool fail) {
		Debug.Log ("Award 2");
	}

	public void GiveAward3(bool fail) {
		Debug.Log ("Award 3");
	}

	public void GiveAward4(bool fail) {
		Debug.Log ("Award 4");
	}

	public void GiveAward5(bool fail) {
		Debug.Log ("Award 5");
	}

	public void GiveAward6(bool fail) {
		Debug.Log ("Award 6");	
	}
}
