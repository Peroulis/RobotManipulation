using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour {

	private GameObject frontCamera;
	private GameObject sideCamera;
	private GameObject endCamera;
	private GameObject roomCamera2;

	void Start () {
		frontCamera = GameObject.Find ("FrontCamera");
		sideCamera = GameObject.Find ("SideCamera");
		endCamera = GameObject.Find ("EndCamera");
		roomCamera2 = GameObject.Find ("RoomCamera2");

		frontCamera.SetActive(true);
		sideCamera.SetActive(false);
		endCamera.SetActive(false);
		roomCamera2.SetActive(false);
	}

	void Update () {
		if(Input.GetKeyDown("c")){
			if (roomCamera2.activeSelf) {
				frontCamera.SetActive (false);
				sideCamera.SetActive (true);
				endCamera.SetActive (false);
				roomCamera2.SetActive (false);
			} else if (sideCamera.activeSelf) {
				sideCamera.SetActive (false);
				frontCamera.SetActive (false);
				endCamera.SetActive (true);
				roomCamera2.SetActive (false);
			} else if (endCamera.activeSelf) {
				sideCamera.SetActive (false);
				frontCamera.SetActive (true);
				endCamera.SetActive (false);
				roomCamera2.SetActive (false);
			} else {
				sideCamera.SetActive (false);
				frontCamera.SetActive (false);
				endCamera.SetActive (false);
				roomCamera2.SetActive (true);
			}
		} 
	}
}
