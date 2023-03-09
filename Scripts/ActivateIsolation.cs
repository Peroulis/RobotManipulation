using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActivateIsolation : MonoBehaviour {

	public GameObject isoX,isoY,isoZ,toggleXiso,toggleYiso,toggleZiso;

	public bool prevStatus;
	public string Status = "No Active Isolation";

	void Awake () {
		isoX = GameObject.Find ("IsolateX");	
		isoY = GameObject.Find ("IsolateY");	
		isoZ = GameObject.Find ("IsolateZ");	

		toggleXiso = GameObject.Find ("Canvas/ToggleXiso");
		toggleYiso = GameObject.Find ("Canvas/ToggleYiso");
		toggleZiso = GameObject.Find ("Canvas/ToggleZiso");

		isoX.gameObject.SetActive (false);
		isoY.gameObject.SetActive (false);
		isoZ.gameObject.SetActive (false);

		toggleXiso.gameObject.SetActive (false);
		toggleYiso.gameObject.SetActive (false);
		toggleZiso.gameObject.SetActive (false);
		prevStatus = false;

	}

	void Update () {
		if (this.GetComponent<AxisButtons> ().clicked == true) {
			toggleXiso.gameObject.SetActive (true);
			toggleYiso.gameObject.SetActive (true);
			toggleZiso.gameObject.SetActive (true);

			if (toggleXiso.GetComponent<Toggle> ().isOn == true) {
				isoX.gameObject.SetActive (true);
			}
			if (toggleYiso.GetComponent<Toggle> ().isOn == true) {
				isoY.gameObject.SetActive (true);
			}
			if (toggleZiso.GetComponent<Toggle> ().isOn == true) {
				isoZ.gameObject.SetActive (true);
			}
			if (prevStatus == false && Status == "No Active Isolation") {
				Status = "Isolation Activated";
				prevStatus = true;
			}

		} else {
			toggleXiso.gameObject.SetActive (false);
			toggleYiso.gameObject.SetActive (false);
			toggleZiso.gameObject.SetActive (false);

			isoX.gameObject.SetActive (false);
			isoY.gameObject.SetActive (false);
			isoZ.gameObject.SetActive (false);
			if (prevStatus == true && Status == "Isolation Activated") {
				Status = "No Active Isolation";
				prevStatus = false;
			}
		}
	}
}
