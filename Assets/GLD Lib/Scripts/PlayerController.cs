﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public bool active = true;

	[Range(0.0f, 20.0f)] public float movementSpeed = 4f;
	[Range(0.0f, 180.0f)] public float rotationSensitivity = 90f;

	[Space(12)]
	public bool canJump = true;
	public KeyCode jumpKey = KeyCode.Space;
	[Range(0.0f, 10.0f)] public float jumpHeight = 1.5f;

	private Rigidbody rb;

	void Start () {
		
		rb = GetComponent<Rigidbody> ();

		//punto di respawn
	/*	if (GlobalControl.Instance.TransitionTarget != null)
			gameObject.transform.position = GlobalControl.Instance.TransitionTarget.position;
		
		if (GlobalControl.Instance.IsSceneBeingLoaded) {

			PlayerState.Instance.localPlayerData = GlobalControl.Instance.LocalCopyOfData;

			transform.position = new Vector3(
				GlobalControl.Instance.LocalCopyOfData.PositionX,
				GlobalControl.Instance.LocalCopyOfData.PositionY,
				GlobalControl.Instance.LocalCopyOfData.PositionZ + 0.1f);

			GlobalControl.Instance.IsSceneBeingLoaded = false;
		}*/
	}

	void Update () {
		//TEMPORANEO!!!/////////
		if(Input.GetKeyDown(KeyCode.R))
			UIController.UI.showImageToast("POZIONE!","Hai trovato una pozione","techno-heart",4);
		if(Input.GetKeyDown(KeyCode.F))
			UIController.UI.showToast("PROVA TESTO!","Gnammete",4);
		//////////////////////////////////////////////////////////

		if (active) {
			if (rb) {
				rb.MovePosition (transform.position + transform.rotation * (Vector3.forward * movementSpeed * (Input.GetAxis ("Vertical") * Time.deltaTime)));
				rb.MoveRotation(Quaternion.Euler(0.0f, rotationSensitivity * (Input.GetAxis ("Horizontal") * Time.deltaTime), 0.0f) * transform.rotation);
		//		PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
		//		PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
		//		PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;
			} else {
				transform.Translate (Vector3.forward * movementSpeed * (Input.GetAxis ("Vertical") * Time.deltaTime));
				transform.Rotate (0.0f, rotationSensitivity * (Input.GetAxis ("Horizontal") * Time.deltaTime), 0.0f, Space.World);
			}

			if (canJump && Input.GetKeyDown (jumpKey)) {
				if (rb) rb.MovePosition (transform.position + Vector3.up * jumpHeight);
				else transform.Translate (jumpHeight * Vector3.up);
			}
		}
	}
}
