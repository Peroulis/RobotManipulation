using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrap : MonoBehaviour {

	private Vector3 pos;
	private GameObject obj = null;
	private bool grap = false;


	void Update () {
		if (grap == true) {
			obj.transform.position = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().flange02.transform.position;
		}
		if (GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().gripper == false) {
			grap = false;
			if (obj != null) {
				obj.transform.position = obj.transform.position;
				obj.GetComponent<Rigidbody> ().isKinematic = false;
			}
		}
	}
	
	void OnTriggerEnter (Collider other) {
		//Debug.Log ("box found");
		if (other.gameObject.name == "Cube") {
			//Debug.Log ("Collision with capsule");
			if (GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().gripper == true) {
				//Debug.Log ("Catch");
				grap = true;
				obj = other.gameObject;
				obj.GetComponent<Rigidbody> ().isKinematic = true;
				//pos = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().flange02.transform.position;
				//other.transform.position = pos;
			}
		}
		
	}
	void OnTriggerExit (Collider other) {
		//Debug.Log ("box lost");
		if (GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().gripper == false) {
			obj.GetComponent<Rigidbody> ().isKinematic = false;
			obj = null;
		}
		}
}
