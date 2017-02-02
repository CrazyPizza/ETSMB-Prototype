using UnityEngine;
using System.Collections;

public enum MovementType { Continuos, fourSided, sixSided };

public class Drive : MonoBehaviour {

	public MovementType kindOfMovement = MovementType.Continuos;

	[Range(1f, 40f)] public float speed = 4f;
	[Range(1f, 360f)] public float rotationSenitivity = 90f;

	[Range(1f, 5f)] public float discreteStep = 1f;
	public bool useLerp = false;


	private Vector3 basePos;
	private Vector3 targetPos;
	private Quaternion baseRot;
	private Quaternion targetRot;
	private float baseTime = 0f;
	private float stepTime = 0f;

	void Start () {
		targetPos = basePos = transform.position;
		targetRot = baseRot = transform.rotation;
	}

	void Update () {

		if (kindOfMovement == MovementType.Continuos) {
			transform.Translate (Vector3.forward * speed * (Input.GetAxis ("Vertical") * Time.deltaTime));
			transform.Rotate (0.0f, rotationSenitivity * (Input.GetAxis ("Horizontal") * Time.deltaTime), 0.0f, Space.World);
			return;
		}

		if (!useLerp) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				transform.Translate (Vector3.forward * discreteStep);
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				transform.Translate (Vector3.back * discreteStep);
			}
			float teta = kindOfMovement == MovementType.fourSided ? 90f : 60f;
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.Rotate (0.0f, teta, 0.0f, Space.World);
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				transform.Rotate (0.0f, -teta, 0.0f, Space.World);
			}
			targetPos = basePos = transform.position;
			targetRot = baseRot = transform.rotation;
		} else {
			if (transform.position != targetPos || transform.rotation != targetRot) {
				float f = (Time.time - baseTime) / stepTime;
				if (f > 1f) f = 1f;
				if (transform.position != targetPos) {
					transform.position = Vector3.Lerp (basePos, targetPos, f);
				}
				if (transform.rotation != targetRot) {
					transform.rotation = Quaternion.Lerp (baseRot, targetRot, f);
				}
				if (f >= 1f) {
					transform.position = targetPos;
					transform.rotation = targetRot;
				}
			} else {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					basePos = transform.position;
					targetPos = basePos + (transform.rotation * Vector3.forward) * discreteStep;
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					basePos = transform.position;
					targetPos = basePos + (transform.rotation * Vector3.back) * discreteStep;
				}
				float teta = kindOfMovement == MovementType.fourSided ? 90f : 60f;
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					baseRot = transform.rotation;
					targetRot = baseRot * Quaternion.Euler (0f, teta, 0f);
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					baseRot = transform.rotation;
					targetRot = baseRot * Quaternion.Euler (0f, -teta, 0f);
				}

				if (transform.position != targetPos || transform.rotation != targetRot) {
					baseTime = Time.time;
					stepTime = discreteStep / speed;
				}
			}
		}
	}
}
