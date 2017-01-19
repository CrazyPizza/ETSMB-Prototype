using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public static UIController UI;

	public Text allyPrefabText;//Prefab del testo della vita degli ally
	private GameObject player; //Riferimento a Jennir
	public Text jennirHPText; //Riferimento alla barra di Jennir
	public GameObject mainCanvas; //Riferimento al main canvas
	public GameObject[] alliesList; //Lista degli alleati da popolare nell'inspector
	private Text[] alliesHealthBars; //Array con la vita degli ally
	private int healthbarOffset=30; //Serve a posizionare in pila le barre della vita
	private int jennirCurrentHP=30;//Variabile che in ogni momento ha dentro gli HP di Jennir
	private int allyCurrentHP=30;//Variabile che in ogni momento ha dentro gli HP dell'alleato valutato
	public GameObject toastImage;//Riferimento al toast con immagine
	public GameObject toastNormale;//Riferimento al toast normale
	public GameObject currentWeaponPanel;//Riferimento al pannello con l'immagine dell'arma in uso


	void Awake() {
		UI=this;
	}

	void Start () {
		initialiseHealthBars();
		if (player.GetComponent<PlayerBaster>().active == true) setCurrentWeaponGUI("Blaster");
        if (player.GetComponent<PlayerLightsaber>().active == true) setCurrentWeaponGUI("Lightsaber");
	}

	void Update () {
		updateHealthBars();
        if (player.GetComponent<PlayerGrenadeLauncer>().active == true) setCurrentWeaponGUI("GrenadeLauncher");
	}

	//
	// GUI-TOASTS
	//
	//TOAST CON IMMAGINE
	public void showImageToast(string heading, string msg, string image, int timeout){
		//SETTA HEADING E TESTO DEL TOAST
		Text headingText=toastImage.GetComponentsInChildren<Text>()[0];
		headingText.text=heading;
		Text contentText=toastImage.GetComponentsInChildren<Text>()[1];
		contentText.text=msg;
		//SETTA IMMAGINE DEL TOAST
		Image contentImage=toastImage.GetComponentsInChildren<Image>()[1];
		contentImage.sprite=Resources.Load<Sprite>("UIAssets/"+image);
		//MOSTRA TOAST
		toastImage.SetActive(true);
		//CHIUDI IL TOAST TRA timeout SECONDI
		Invoke("hideToast", timeout);
	}
	//CHIUDI I TOAST
	void hideToast(){
		toastImage.SetActive(false);
		toastNormale.SetActive(false);
	}

	//TOAST CON SOLO TESTO
	public void showToast(string heading, string msg, int timeout){
		//SETTA HEADING E TESTO DEL TOAST
		Text headingText=toastNormale.GetComponentsInChildren<Text>()[0];
		headingText.text=heading;
		Text contentText=toastNormale.GetComponentsInChildren<Text>()[1];
		contentText.text=msg;
		//MOSTRA TOAST
		toastNormale.SetActive(true);
		//CHIUDI IL TOAST TRA timeout SECONDI
		Invoke("hideToast", timeout);
	}



	//
	// GUI-HEALTH BARS
	//
	void initialiseHealthBars(){
		alliesHealthBars=new Text[alliesList.Length];
		//INIZIALIZZA LA BARRA DI JENNIR
		player= GameObject.FindWithTag ("Player");
		jennirHPText.text="Jennir: "+player.GetComponentInChildren<StatsInfo>().HP;
		//INIZIALIZZA LE BARRE DEGLI ALLEATI
		for(int i=0; i<alliesList.Length; i++){
			alliesHealthBars[i]=Instantiate(allyPrefabText);
			alliesHealthBars[i].rectTransform.SetParent(mainCanvas.transform);
			alliesHealthBars[i].rectTransform.anchoredPosition=new Vector2(jennirHPText.rectTransform.anchoredPosition.x,
				jennirHPText.rectTransform.anchoredPosition.y-healthbarOffset);
			healthbarOffset+=30;
		}
	}

	void updateHealthBars(){
		//Arrotondato a numero intero per evitare problemi di visualizzazione nella healthbar
		//UPDATE BARRA DI JENNIR
		jennirCurrentHP=Mathf.RoundToInt(player.GetComponentInChildren<StatsInfo>().HP);
		jennirHPText.text="JENNIR: "+jennirCurrentHP;
		//UPDATE BARRA DEGLI ALLEATI
		for(int i=0; i<alliesList.Length; i++){
			if(alliesList[i]!=null){
				allyCurrentHP=Mathf.RoundToInt(alliesList[i].GetComponentInChildren<StatsInfo>().HP);
				alliesHealthBars[i].text="ALLY: "+allyCurrentHP;
			}else{
				alliesHealthBars[i].text="ALLY: DEAD";
			}
		}
	}

	//
	// GUI-CURRENT WEAPON
	//
	public void setCurrentWeaponGUI(string arma){

		Text currentWeaponText=currentWeaponPanel.GetComponentsInChildren<Text>()[0];
		Image currentWeaponImage=currentWeaponPanel.GetComponentsInChildren<Image>()[1];

		switch(arma){
		case "Lightsaber":
			currentWeaponImage.sprite=Resources.Load<Sprite>("UIAssets/LightsaberIcon");
			currentWeaponText.text=arma + " : L (on/off) - O (attack)";
			break;
		case "GrenadeLauncher":
			currentWeaponImage.sprite=Resources.Load<Sprite>("UIAssets/GrenadelauncherIcon");
			currentWeaponText.text=arma + " : P";
			break;
		default://blaster
			currentWeaponImage.sprite=Resources.Load<Sprite>("UIAssets/BlasterIcon");
			currentWeaponText.text="Blaster : E";
			break;
		}
	}

}


