using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : MonoBehaviour {

	private Vector3[] values;
	private int length = 10;
	public Vector3[] movingAverage;

	private GameObject myo;

	private float nextTime = 0;
	private float timeWait = 0.1f; // 0.1 = 10 Hz



	void Start () {
		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		values = new Vector3[length];
		movingAverage = new Vector3[1];
	}
	

	void Update () {
		if (Time.time >= nextTime) {
			values [length - 1] = new Vector3(myo.GetComponent<ThalmicMyo>().gyroscope.x,
												myo.GetComponent<ThalmicMyo>().gyroscope.y,
													myo.GetComponent<ThalmicMyo>().gyroscope.z); 

			for (int j = 1 ; j < length ; j++){
				values [j - 1] = values [j];
			}

			for (int j = 1; j < length; j++) {
				movingAverage[0].x = movingAverage[0].x + values [j - 1].x;
				movingAverage[0].y = movingAverage[0].y + values [j - 1].y;
				movingAverage[0].z = movingAverage[0].z + values [j - 1].z;
			}
			movingAverage[0].x = movingAverage[0].x / length;
			movingAverage[0].y = movingAverage[0].y / length;
			movingAverage[0].z = movingAverage[0].z / length;
			nextTime += timeWait;
		}
	}
}
