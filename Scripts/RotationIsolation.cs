using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationIsolation : MonoBehaviour {

	private float xRotPre,yRotPre,zRotPre,xGPre,yGPre,zGPre;
	private GameObject myo;

	private float dx, dy, dz, xG, yG, zG;

	public float percFilter;

	public float x4Rot,y4Rot,z4Rot;

	private float xRot,yRot,zRot;

	private float nextTime = 0;
	private float timeWait = 0.1f; // 0.1 = 10 Hz

	private float xRR, yRR, zRR;

	public GameObject buttonIso;


	void Start () {
		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		buttonIso = GameObject.Find ("AxisButtons(Canvas)/Button:IsolateAxis");
		xRotPre = 0;
		yRotPre = 0;
		zRotPre = 0;

		xRR = 0;
		yRR = 0;
		zRR = 0;

		percFilter = 0.0f;

		nextTime = Time.time;

		x4Rot = 0;
		y4Rot = 90;
		z4Rot = 0;
	}

	void Update () {
		
		if (Time.time <= 3.0f || Input.GetKeyDown ("r")) {
			xGPre = 0;
			yGPre = 0;
			zGPre = 0;
			xRotPre = 0;
			yRotPre = 90;
			zRotPre = 0;

			xRR = 0;
			yRR = 0;
			zRR = 0;

			x4Rot = 0;
			y4Rot = 0;
			z4Rot = 0;
		}
			
		if (buttonIso.GetComponent<AxisButtons> ().clicked == true) {
			
			xG = myo.GetComponent<ThalmicMyo> ().gyroscope.y;
			yG = myo.GetComponent<ThalmicMyo> ().gyroscope.x;
			zG = myo.GetComponent<ThalmicMyo> ().gyroscope.z;
		
			xRot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().xR;
			yRot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().yR;
			zRot = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().zR;

			dx = xG - xGPre;
			dy = yG - yGPre;
			dz = zG - zGPre;

			dx = Mathf.Abs (xG);
			dy = Mathf.Abs (yG);
			dz = Mathf.Abs (zG);

			if (dx > dy && dx > dz && dx - dy > percFilter && dx - dz > percFilter) {
				x4Rot = xRot + xRR;
				y4Rot = yRotPre;
				z4Rot = zRotPre;

				yRR = y4Rot - yRot;
				zRR = z4Rot - zRot;

				xRotPre = x4Rot;
			} else if (dy > dx && dy > dz && dy - dx > percFilter && dy - dz > percFilter) {
				y4Rot = yRot + yRR;
				x4Rot = xRotPre;
				z4Rot = zRotPre;

				xRR = x4Rot - xRot;
				zRR = z4Rot - zRot;

				yRotPre = y4Rot;
			} else if (dz > dx && dz > dy && dz - dx > percFilter && dz - dy > percFilter) {
				z4Rot = zRot + zRR;

				x4Rot = xRotPre;
				y4Rot = yRotPre;

				yRR = y4Rot - yRot;
				xRR = x4Rot - xRot;

				zRotPre = z4Rot;
			} else {
				x4Rot = xRotPre;
				y4Rot = yRotPre;
				z4Rot = zRotPre;

				xRR = x4Rot - xRot;
				yRR = y4Rot - yRot;
				zRR = z4Rot - zRot;

			}
			xGPre = xG;
			yGPre = yG;
			zGPre = zG;

			nextTime += timeWait;

		} else {
			xRotPre = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().xR;
			yRotPre = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().yR;
			zRotPre = GameObject.Find ("Staubli").GetComponent<EulerAngles> ().zR;

			x4Rot = xRotPre;
			y4Rot = yRotPre;
			z4Rot = zRotPre;
		}
	}
}