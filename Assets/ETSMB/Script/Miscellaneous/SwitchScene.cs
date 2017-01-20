using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    public string nameScene;

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == ("PlayerBody"))
            //Inserire il nome della scena (ogni video che parte è una scena)
            SceneManager.LoadScene(nameScene);
    }
}
