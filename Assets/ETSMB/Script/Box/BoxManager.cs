using UnityEngine;
using System.Collections;

public class BoxManager : MonoBehaviour {

	private bool fail;

	public void Open(GameObject box) {
		
		GameObject player = GameObject.FindWithTag ("Player");
		int dex = player.GetComponentInChildren<StatsInfo> ().DEX;
		int i = Random.Range (1, 20);
		fail = (i <= dex) ? false : true;

        Award award = new Award();

		switch (box.name) {
			case "Box 1":
				award.GiveAward1(fail);
				break;
			case "Box 2":
				award.GiveAward2(fail);
				break;
			case "Box 3":
				award.GiveAward3(fail);
				break;
			case "Box 4":
				award.GiveAward4(fail);
				break;
			case "Box 5":
				award.GiveAward5(fail);
				break;
			case "Box 6":
				award.GiveAward6(fail);
				break;
            case "Box 7":
                award.GiveAward7(fail);
                break;
		}
	}
}
