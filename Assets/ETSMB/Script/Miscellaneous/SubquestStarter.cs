using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SubquestStarter : MonoBehaviour {

	private bool playerInRange=false;
	public KeyCode key= KeyCode.E;

    // Update is called once per frame
    void Update () {
		if(playerInRange && Input.GetKeyDown(key)){
            if (this.gameObject.tag == "NPC Witch") {
                SceneManager.LoadScene("Back_To_Orvax4_Video_Subquest_Start"); //VAI ALLA SUBQUEST
            } else if (this.gameObject.tag == "Go To Run")
                SceneManager.LoadScene("Back_To_Orvax4_Video_Run_Start"); //VAI ALLA RUN
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag=="Player"){
			playerInRange=true;
		}
        if (this.gameObject.tag == "NPC Witch" && playerInRange)
            UIController.UI.showToast("INIZIA SUBQUEST", "PREMI E PER INIZIARE LA SUBQUEST", 3);
        else if (this.gameObject.tag == "Go To Run" && playerInRange)
            UIController.UI.showToast("INIZIA PARTE 3", "PREMI E PER ANDARE ALLA PARTE 3 (THE RUN)", 3);
	}

	void OnCollisionExit(Collision other){
		if(other.gameObject.tag=="Player"){
			playerInRange=false;
		}
	}
}
