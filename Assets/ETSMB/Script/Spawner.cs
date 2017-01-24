using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject[] DianogaPrefab;
	public GameObject[] DianogaClone;
	public bool inTrigger;

	void OnTriggerEnter(Collider other)
	{
		inTrigger = true;
	}

	void OnTriggerExit(Collider other)
	{
		inTrigger = false;
	}

	void Update()
	{
		if (inTrigger)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				DianogaClone[0] = Instantiate(DianogaPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
				Destroy(this.gameObject);
			}
		}
	}

	void OnGUI()
	{
		if (inTrigger)
		{
			GUI.Box(new Rect(0, 60, 200, 25), "Press E to unlock the door");
		}
	}
}
