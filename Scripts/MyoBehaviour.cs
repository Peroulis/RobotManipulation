using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyoBehaviour : MonoBehaviour {

	private GameObject myo;
	public float rotx,roty,rotz,posx,posy;
	public Vector3 startRot;

	void Start () {
		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		this.transform.eulerAngles = new Vector3 (0, 90, 0);
	}

	void Update () {
		if (Time.time <= 3.0f || Input.GetKeyDown ("r")) {
			startRot.x = myo.transform.eulerAngles.x;
			startRot.y = myo.transform.eulerAngles.y;
			startRot.z = myo.transform.eulerAngles.z;
		}
		rotx = myo.transform.eulerAngles.x;
		roty = myo.transform.eulerAngles.y;
		rotz = myo.transform.eulerAngles.z;

		this.transform.eulerAngles = new Vector3 (rotx, roty, rotz) - startRot;
	}
}