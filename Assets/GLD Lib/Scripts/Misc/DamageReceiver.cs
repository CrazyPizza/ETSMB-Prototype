using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageReceiver : MonoBehaviour {

	public bool active = true;

	private StatsInfo si;
	private GameObject attacker;
	private GameObject defender;

	void Start() {

		si = GetComponentInChildren<StatsInfo> ();

	}

	public void ReceiveDamage(int i) {

		if (active) {

			if (si.gameObject.tag == "NPC Enemy") {

				si.HP -= i;
				if (si.HP <= 0) {
					Debug.Log ("Enemy Morto");
					Destroy (si.gameObject);
				}

			if (si.gameObject.tag == "NPC Ally") {

				si.HP -= i;
				if (si.HP <= 0) {
					Debug.Log ("Ally Morto");
					Destroy (si.gameObject);
				}
			}
				// Con gioco avviato vedi log in console quando il player è nell'area del nemico ma l'alleato è fuori
				// non ci sono danni al giocatore, appena l'alleato entra nell'area il giocatore subisce danno
			} else {

				PlayerState.Instance.localPlayerData.HP -= i;
				if (PlayerState.Instance.localPlayerData.HP <= 0) {

					GlobalControl.Instance.LoadData();
					GlobalControl.Instance.IsSceneBeingLoaded = true;
				
					int whichScene = GlobalControl.Instance.LocalCopyOfData.SceneID;
			
					//Application.LoadLevel(whichScene);
					SceneManager.LoadScene(whichScene);
				}
			}
		}
	}
}