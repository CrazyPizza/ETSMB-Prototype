using UnityEngine;
using System.Collections;

public class SpawnerBox : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject[] DianogaPrefab;
	public GameObject[] DianogaClone;

	void Start(){
		spawnEnemy ();
	}


	void spawnEnemy(){
		DianogaClone[0] = Instantiate(DianogaPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
	}
}

//copia funzionante spown enemy
