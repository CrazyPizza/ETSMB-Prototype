using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageReceiver : MonoBehaviour {

	public bool active = true;

	private StatsInfo si;

	void Start() {
		si = GetComponentInChildren<StatsInfo> ();
	}

	public void ReceiveDamage(int i) {

		if (active) {
			if (PlayerState.Instance.localPlayerData.NAME == "Dass Jennir") {
				PlayerState.Instance.localPlayerData.HP -= i;
				if (PlayerState.Instance.localPlayerData.HP <= 0) {
					Debug.Log ("Morto");
					GlobalControl.Instance.LoadData();
					GlobalControl.Instance.IsSceneBeingLoaded = true;

					int whichScene = GlobalControl.Instance.LocalCopyOfData.SceneID;

					//Application.LoadLevel(whichScene);
					SceneManager.LoadScene(whichScene);
				}
			} else {
				si.HP -= i;
				if (si.HP <= 0)
					Destroy (si.gameObject);
			}

		}
	}
}