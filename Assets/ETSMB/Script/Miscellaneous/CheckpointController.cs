using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	public GameObject[] enemiesList; //Lista dei nemici da popolare nell'inspector PER ORA NON SERVE
	public Transform[] enemiesPositions; //non usata attualmente
	public GameObject[] alliesList; //Lista degli alleati da popolare nell'inspector
	public GameObject[] checkpointList; //Lista dei checkpoint, la posizione nella lista deve rispecchiare il numero del checkpoint
	public GameObject player; //Riferimento al player
	public int activeCheckpoint=0; //Public per un controllo veloce nell'inspector
	private int playerHP=0;
	private int initialHP=0;

	void Start () {
		//Prende le posizioni di partenza dei nemici, usate per resettarli nel loro punto originario
		//NON ANCORA IMPLEMENTATO
		initialHP = (int) player.GetComponentInChildren<StatsInfo>().HP;
		enemiesPositions=new Transform[enemiesList.Length];
		for(int i=0; i< enemiesList.Length; i++){
			enemiesPositions[i]=enemiesList[i].transform;
		}
	}

	void Update () {
		//Se il player muore, resetta dal checkpoint attualmente attivo
		playerHP = (int) player.GetComponentInChildren<StatsInfo>().HP;
		if (playerHP <= 0) {
			resetToCheckpoint();
		}

	}

	void resetToCheckpoint(){
		GameObject activeCheckpointObj= checkpointList[this.activeCheckpoint];
		//Posizione scomposta nelle 3 primitive per poter settare dopo la posizione corretta di respawn
		float checkP_X =activeCheckpointObj.transform.position.x;
		float checkP_Y =activeCheckpointObj.transform.position.y;
		float checkP_Z =activeCheckpointObj.transform.position.z;
		int offset=1;//Per non far respawnare gli alleati in testa ad altri alleati

		//Reset della vita del player e riposizionamento al checkpoint
		player.GetComponentInChildren<StatsInfo>().HP=initialHP;
		player.transform.position=activeCheckpointObj.transform.position;
		//Riposizionamento di tutti gli alleati NON morti. Se sono morti sono null nel vettore e quindi li ignora
		for(int i=0; i< alliesList.Length; i++){
			if(alliesList[i]!=null){
				alliesList[i].transform.position=new Vector3(checkP_X+offset, checkP_Y, checkP_Z);
				offset++;
			}
		}
	}

	//Richiamato dai singoli checkpoint per impostare il checkpoint da cui respawnare
	public void setActiveCheckpoint(int checkpointNum){
		this.activeCheckpoint=checkpointNum;
		Debug.Log("attivato il checkpoint "+this.activeCheckpoint);
	}
}
