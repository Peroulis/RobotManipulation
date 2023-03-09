using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EulerAngles : MonoBehaviour {

	private GameObject myo, staubli;
	public float xR, yR, zR;
	private float xStaubli, yStaubli, zStaubli;
	private float lastX,lastY,lastZ, dif;

	private float nextTime = 0;
	private float timeWait = 0.1f;

	public bool LowPassFilter;
	public Vector3[] _3dFilter;
	public float minFilter;

	public float maxFilter;
	public string rotationAxis;

	private Toggle tg;

	void Start(){
		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		staubli = GameObject.Find ("Staubli");
		_3dFilter = new Vector3[1];
		minFilter = 0.0f;
		LowPassFilter = false;
		tg = GameObject.Find ("AxisButtons(Canvas)/Toggle:LowFilter").GetComponent<Toggle> ();
	}

	void Update ()
	{			
		if (Time.time <= 3.0f || Input.GetKeyDown ("r")) {
			xR = 0;
			yR = 90;
			zR = 0;

			xStaubli = myo.transform.eulerAngles.x;
			yStaubli = myo.transform.eulerAngles.y;
			zStaubli = myo.transform.eulerAngles.z;
		}

		if (tg.isOn) {
			minFilter = GameObject.Find ("AxisButtons(Canvas)/Slider:LowFilter").GetComponent<Slider> ().value;
			LowPassFilter = true;
		} else
			LowPassFilter = false;

		_3dFilter = staubli.GetComponent<Filter> ().movingAverage;
		maxFilter = Mathf.Max (Mathf.Abs(_3dFilter[0].x),Mathf.Abs(_3dFilter[0].y),Mathf.Abs(_3dFilter[0].z));

		if (maxFilter == Mathf.Abs (_3dFilter [0].x)) {
			rotationAxis = "y";
		} else if (maxFilter == Mathf.Abs (_3dFilter [0].y)) {
			rotationAxis = "x";
		} else
			rotationAxis = "z";
		
		if (maxFilter < minFilter) {
			maxFilter = minFilter;
		}
//-----------------------------------------------------------------------------------------------------
		if (LowPassFilter == true) {
			if (rotationAxis == "x" && (Mathf.Abs (myo.GetComponent<ThalmicMyo> ().gyroscope.x) >= minFilter)){
				dif = myo.transform.eulerAngles.x - xStaubli;
			} else { 
				if (Mathf.Abs (myo.GetComponent<ThalmicMyo> ().gyroscope.x) >= maxFilter) {
					dif = myo.transform.eulerAngles.x - xStaubli; 
				} else
					dif = 0;
			}

		} else 
			dif = myo.transform.eulerAngles.x - xStaubli; 

		if (Mathf.Abs(dif) > 300) {
			dif = Mathf.Abs(dif) - 360;
		} 
		   
		xR = xR + dif;
		xStaubli = myo.transform.eulerAngles.x;
//-----------------------------------------------------------------------------------------------------

		if (LowPassFilter == true) {
			if (rotationAxis == "y" && (Mathf.Abs (myo.GetComponent<ThalmicMyo> ().gyroscope.y) >= minFilter)) {
				dif = myo.transform.eulerAngles.y - yStaubli;
			} else { 
				if (Mathf.Abs (myo.GetComponent<ThalmicMyo> ().gyroscope.y) >= maxFilter) {
					dif = myo.transform.eulerAngles.y - yStaubli; 
				} else
					dif = 0;
			}

		} else 
			dif = myo.transform.eulerAngles.y - yStaubli; 
		
		if (Mathf.Abs(dif) > 300) {
			dif = Mathf.Abs(dif) - 360;
		} 

		yR = yR + dif;
		yStaubli = myo.transform.eulerAngles.y;
//-----------------------------------------------------------------------------------------------------
		if (LowPassFilter == true) {
			if (rotationAxis == "z" && (Mathf.Abs (myo.GetComponent<ThalmicMyo> ().gyroscope.z) >= minFilter)) {
				dif = myo.transform.eulerAngles.z - zStaubli;
			} else { 
				if (Mathf.Abs (myo.GetComponent<ThalmicMyo> ().gyroscope.z) >= maxFilter) {
					dif = myo.transform.eulerAngles.z - zStaubli; 
				} else
					dif = 0;
			}

		} else 
			dif = myo.transform.eulerAngles.z - zStaubli; 
		
		if (Mathf.Abs(dif) > 300) {
			dif = Mathf.Abs(dif) - 360;
		} 

		zR = zR + dif;
		zStaubli = myo.transform.eulerAngles.z;

		nextTime += timeWait;

		//Debug.Log (myo.transform.eulerAngles);
		// 289 306 20
	}

}