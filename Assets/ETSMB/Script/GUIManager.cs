using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    private StatsInfo si;
    private int barLength;

	void Start () {

        si = GetComponentInChildren<StatsInfo>();
        barLength = Screen.width / 7;

	}

	void Update () {
	    
	}

    void OnGUI() {

        GUI.Box(new Rect(5, 30, 50, 20), "HP");

        GUI.Box(new Rect(45, 30, barLength, 20), si.HP.ToString() + "30");
    }

}
