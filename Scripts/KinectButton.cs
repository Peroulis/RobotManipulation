using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KinectButton : MonoBehaviour {

	private GameObject kinnect;

	void Start () {
		kinnect = GameObject.Find ("Hub - 1 Myo/Myo");

		this.GetComponent<Image> ().color = Color.white;
	}

	void Update () {
		if (false) {
			this.GetComponent<Image>().color = Color.green;
		}
	}
}