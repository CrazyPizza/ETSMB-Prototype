using UnityEngine;
using System.Collections;

public class BoxManager : MonoBehaviour {

	public Achive1 achive;
	private bool fail;

	public void Open() {
		
		GameObject player = GameObject.FindWithTag ("Player");
		int dex = player.GetComponentInChildren<StatsInfo> ().DEX;
		Debug.Log("Player Dex: " + dex);
		int i = Random.Range (1, 20);
		fail = (i <= dex) ? false : true;
		Debug.Log ("Random Dex: " + i);
		Debug.Log ("Fail: " + fail);
		achive.GiveAchive (fail);

	}
}
