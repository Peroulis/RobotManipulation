using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyoButton : MonoBehaviour {

	private GameObject myo;

	void Start () {
		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		this.GetComponent<Image> ().color = Color.white;
	}

	void Update () {
		if (myo.GetComponent<ThalmicMyo> ().armSynced == true) {
			this.GetComponent<Image> ().color = Color.green;
		} else
			this.GetComponent<Image> ().color = Color.white;
	}
}