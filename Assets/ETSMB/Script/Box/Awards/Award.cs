using UnityEngine;
using System.Collections;

public class Award {

	GameObject player = GameObject.FindWithTag ("Player");

	public void GiveAward1(bool fail) {
        if(fail == false) {
            player.GetComponentInChildren<StatsInfo>().HP += (player.GetComponentInChildren<StatsInfo>().HP * 0.2F);
            UIController.UI.showImageToast("SUCCESS","You found a potion, +20% HP","PotionIcon",4);
        } else {
            player.GetComponentInChildren<StatsInfo>().HP -= (player.GetComponentInChildren<StatsInfo>().HP * 0.2F);
            UIController.UI.showImageToast("FAIL","A snake bit you, -20% HP","SnakeIcon",4);
        }
	}

	public void GiveAward2(bool fail) {
        if(fail == false) {
            player.GetComponentInChildren<StatsInfo>().HP += (player.GetComponentInChildren<StatsInfo>().HP * 0.2F);
            UIController.UI.showImageToast("SUCCESS","You found a potion, +20% HP","PotionIcon",4);
        } else {
            UIController.UI.showImageToast("FAIL","The box stay locked permanently","LockIcon",4);
        }
    }

	public void GiveAward3(bool fail) {
        if(fail == false) {
            player.GetComponentInChildren<PlayerGrenadeLauncer>().active = true;
            UIController.UI.showImageToast("SUCCESS", "You found a grenade launcher", "GrenadelauncherIcon", 4);
        } else {
            player.GetComponentInChildren<StatsInfo>().HP -= (player.GetComponentInChildren<StatsInfo>().HP * 0.2F);
            UIController.UI.showImageToast("FAIL", "Some rocks fall and hit the box", "RockIcon", 4);
        }
	}

	public void GiveAward4(bool fail) {
        if(fail == false) {
            player.GetComponentInChildren<PlayerGrenadeLauncer>().addGranade(1);
            UIController.UI.showImageToast("SUCCESS","You found 1 grenade extra","GrenadeIcon",4);
        } else {
            player.GetComponentInChildren<StatsInfo>().HP -= (player.GetComponentInChildren<StatsInfo>().HP * 0.2F);
            UIController.UI.showImageToast("FAIL","Some rocks fall and hit the box","RockIcon",4);
        }
    }

	public void GiveAward5(bool fail) {
		if (fail == false) {
			UIController.UI.showImageToast("SUCCESS","You found 10 credits","CoinIcon",3);
        } else {
			UIController.UI.showImageToast("FAIL","The box was empty","LockIcon",3);
        }
	}

	public void GiveAward6(bool fail) {
        if (fail == false) {
            player.GetComponentInChildren<StatsInfo>().HP += (player.GetComponentInChildren<StatsInfo>().HP * 0.35F);
            UIController.UI.showImageToast("SUCCESS", "You found a potion, +35% HP", "PotionIcon", 4);
        } else {
            UIController.UI.showImageToast("FAIL", "The box stay locked permanently", "LockIcon", 4);
        }
    }
}