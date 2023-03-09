using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyoPosition : MonoBehaviour {

	public float xRot,x2Rot;
	public float yRot,y2Rot;
	public float zRot,z2Rot;
	/*
	public float xPos,x2Pos;
	public float yPos,y2Pos;
	public float zPos,z2Pos;
*/
	public float xGyro,x2Gyro;
	public float yGyro,y2Gyro;
	public float zGyro,z2Gyro;

	public float xAcc,x2Acc;
	public float yAcc,y2Acc;
	public float zAcc,z2Acc;
	/*
	public float xVel,x2Vel;
	public float yVel,y2Vel;
	public float zVel,z2Vel;

	public float xPosPre,x2PosPre;
	public float yPosPre,y2PosPre;
	public float zPosPre,z2PosPre;

	public float xAccPre,x2AccPre;
	public float yAccPre,y2AccPre;
	public float zAccPre,z2AccPre;

	private float xVelPre,x2VelPre;
	private float yVelPre,y2VelPre;
	private float zVelPre,z2VelPre;
*/
	private GameObject myo;
	private float nextTime = 0;
	private float timeWait = 0.1f;
	//private float prevTime = 0.0f;c

	public GameObject buttonIso;
	 

	void Start () {
		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		buttonIso = GameObject.Find ("AxisButtons(Canvas)/Button:IsolateAxis");
		/*
		xAccPre = myo.GetComponent<ThalmicMyo> ().accelerometer.x;
		xVelPre = 0;
		xPosPre = 0;
		yAccPre = -myo.GetComponent<ThalmicMyo> ().accelerometer.y;
		yVelPre = 0;
		yVelPre = 0;
		yPosPre = 0;
		zAccPre = myo.GetComponent<ThalmicMyo> ().accelerometer.z;
		zVelPre = 0;
		zVelPre = 0;
		zPosPre = 0;

		xPos = 0;
		yPos = 0;
		zPos = 0;
		*/
	}
	
	void FixedUpdate ()
	{
		if (Time.time <= 3.0f || Input.GetKeyDown ("r")) {
			
			xRot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().xR;
			yRot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().yR;
			zRot = GameObject.Find("Staubli").GetComponent<EulerAngles> ().zR;

			xGyro = myo.GetComponent<ThalmicMyo> ().gyroscope.x;
			yGyro = myo.GetComponent<ThalmicMyo> ().gyroscope.y;
			zGyro = myo.GetComponent<ThalmicMyo> ().gyroscope.z;
			xAcc = myo.GetComponent<ThalmicMyo> ().accelerometer.x;
			yAcc = myo.GetComponent<ThalmicMyo> ().accelerometer.y;
			zAcc = myo.GetComponent<ThalmicMyo> ().accelerometer.z;
			/*
			xPos = 0;
			yPos = 0;
			zPos = 0;
			xPosPre = 0;
			yPosPre = 0;
			zPosPre = 0;
			xAccPre = 0;
			yAccPre = 0;
			zAccPre = 0;
			xVelPre = 0;
			yVelPre = 0;
			zVelPre = 0;
			*/
		}

		if (Time.time > nextTime) {
			nextTime += timeWait;

			if (buttonIso.GetComponent<AxisButtons> ().clicked == false) {
				x2Rot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().xR;
				y2Rot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().yR;
				z2Rot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().zR;
			} else {
				x2Rot = myo.GetComponent<RotationIsolation> ().x4Rot;
				y2Rot = myo.GetComponent<RotationIsolation> ().y4Rot;
				z2Rot = myo.GetComponent<RotationIsolation> ().z4Rot;
			}

			x2Acc = myo.GetComponent<ThalmicMyo> ().accelerometer.x - xAcc;
			y2Acc = myo.GetComponent<ThalmicMyo> ().accelerometer.y - yAcc;
			z2Acc = myo.GetComponent<ThalmicMyo> ().accelerometer.z - zAcc;

			/*
			x2Gyro = myo.GetComponent<ThalmicMyo> ().gyroscope.y;
			y2Gyro = myo.GetComponent<ThalmicMyo> ().gyroscope.x;
			z2Gyro = myo.GetComponent<ThalmicMyo> ().gyroscope.z;

			
			xVel = xVelPre + (x2Acc - xAccPre) / (nextTime - prevTime);
			xPos = xPosPre + (xVel - xVelPre) / (nextTime - prevTime);

			xPosPre = xPos;
			xAccPre = x2Acc;
			xVelPre = xVel;

			yVel = yVelPre + (y2Acc - yAccPre) / (nextTime - prevTime);
			yPos = yPosPre + (yVel - yVelPre) / (nextTime - prevTime);

			yPosPre = yPos;
			yAccPre = y2Acc;
			yVelPre = yVel;

			zVel = zVelPre + (z2Acc - zAccPre) / (nextTime - prevTime);
			zPos = zPosPre + (zVel - zVelPre) / (nextTime - prevTime);

			zPosPre = zPos;
			zAccPre = z2Acc;
			zVelPre = zVel;
			*/
		}
	}
}