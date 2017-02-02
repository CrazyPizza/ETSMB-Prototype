using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    public string nameScene;

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == ("PlayerBody")) {
            SceneManager.LoadScene(nameScene);
        }
    }
}
