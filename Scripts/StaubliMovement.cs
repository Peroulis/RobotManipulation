using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose = Thalmic.Myo.Pose;

public class StaubliMovement : MonoBehaviour {

	private GameObject myo;

	private GameObject shoulder;
	private GameObject arm;
	private GameObject elbow;
	private GameObject forearm;
	private GameObject wrist;
	private GameObject flange01;
	public GameObject flange02;

	public float rotation_joint_1;
	public float rotation_joint_2;
	public float rotation_joint_3;
	public float rotation_joint_4;
	public float rotation_joint_5;
	public float rotation_joint_6;

	public float forearmRotation;
	public bool gripper = false;


	private float pre_joint_1,pre_joint_2,pre_joint_3,pre_joint_4,pre_joint_5;

	public float movementGain;

	private float dif = 0.0f ;

	//public Pose pose;

	void Awake () {
		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		//robotBase = GameObject.Find ("(#25) RX90BL BASE HORIZONTAL CABLE OUTLET");
		shoulder = GameObject.Find ("(#3359) RX90BL SHOULDER");
		arm = GameObject.Find ("(#4480) RX90BL ARM");
		elbow = GameObject.Find ("(#5451) RX90BL ELBOW");
		forearm = GameObject.Find ("(#6667) RX90BL FOREARM");
		wrist = GameObject.Find ("(#10353) RX90BL WRIST");
		flange01 = GameObject.Find ("(#11508) RX90BL TOOL FLANGE");
		flange02 = GameObject.Find ("(#11508) RX90BL TOOL FLANGE_2");

		rotation_joint_1 = 90;
		rotation_joint_2 = 0;
		rotation_joint_3 = 0;
		rotation_joint_4 = 0;
		rotation_joint_5 = 0;
		rotation_joint_6 = 0;

		movementGain = 1.5f;

		pre_joint_1 = 90;
	}

	void Update () {
		
		shoulder.transform.localRotation = Quaternion.Euler(0,0,rotation_joint_1);
		arm.transform.localRotation = Quaternion.Euler(0,rotation_joint_2,0);
		elbow.transform.localRotation = Quaternion.Euler(0,rotation_joint_3,0);
		forearm.transform.localRotation = Quaternion.Euler(0,0,rotation_joint_4);
		wrist.transform.localRotation = Quaternion.Euler(0,rotation_joint_5,0);
		flange01.transform.localRotation = Quaternion.Euler (0, 0, rotation_joint_6);

		if (GameObject.Find ("AxisButtons(Canvas)/Button:IsolateAxis").GetComponent<AxisButtons> ().clicked == true) { 
			if (GameObject.Find ("Buttton:Shoulder").GetComponent<AxisButtons> ().clicked == true) {
				dif = myo.GetComponent<RotationIsolation> ().y4Rot - pre_joint_1;
				rotation_joint_1 = rotation_joint_1 + dif*movementGain;
				pre_joint_1 = dif + pre_joint_1;
				//rotation_joint_1 = myo.GetComponent<RotationIsolation> ().y4Rot*movementGain;
			}
			
			if (GameObject.Find ("Buttton:Arm").GetComponent<AxisButtons> ().clicked == true) {
				rotation_joint_2 = myo.GetComponent<RotationIsolation> ().x4Rot*movementGain - rotation_joint_3;
			} else if (GameObject.Find ("Buttton:Elbow").GetComponent<AxisButtons> ().clicked == true) {
				rotation_joint_3 = myo.GetComponent<RotationIsolation> ().x4Rot*movementGain - rotation_joint_2;
			}
			if (GameObject.Find ("Buttton:Forearm").GetComponent<AxisButtons> ().clicked == true) {
				dif = myo.GetComponent<RotationIsolation> ().z4Rot - pre_joint_4;
				rotation_joint_4 = rotation_joint_4 + dif*movementGain;
				pre_joint_4 = dif + pre_joint_4;
				//rotation_joint_4 = myo.GetComponent<RotationIsolation> ().z4Rot*movementGain; 
			}
		} else {
			if (GameObject.Find ("Buttton:Shoulder").GetComponent<AxisButtons> ().clicked == true) {
				dif = myo.GetComponent<MyoPosition> ().y2Rot - pre_joint_1;
				rotation_joint_1 = rotation_joint_1 + dif*movementGain;
				pre_joint_1 = dif + pre_joint_1;
				//rotation_joint_1 = myo.GetComponent<MyoPosition> ().y2Rot*movementGain;
			}
			if (GameObject.Find ("Buttton:Arm").GetComponent<AxisButtons> ().clicked == true) {
				rotation_joint_2 = myo.GetComponent<MyoPosition> ().x2Rot*movementGain - rotation_joint_3;
			} else if (GameObject.Find ("Buttton:Elbow").GetComponent<AxisButtons> ().clicked == true) {
				rotation_joint_3 = myo.GetComponent<MyoPosition> ().x2Rot*movementGain - rotation_joint_2;
			}
			if (GameObject.Find ("Buttton:Forearm").GetComponent<AxisButtons> ().clicked == true) {
				dif = myo.GetComponent<MyoPosition> ().z2Rot - pre_joint_4;
				rotation_joint_4 = rotation_joint_4 + dif*movementGain;
				pre_joint_4 = dif + pre_joint_4;
				//rotation_joint_4 = myo.GetComponent<MyoPosition> ().z2Rot*movementGain;
			}
		}

		if (myo.GetComponent<ThalmicMyo> ().pose == Pose.WaveIn) {
			rotation_joint_5 = rotation_joint_5 + 0.5f;
		} else if (myo.GetComponent<ThalmicMyo> ().pose == Pose.WaveOut) {
			rotation_joint_5 = rotation_joint_5 - 0.5f;
		} else if (myo.GetComponent<ThalmicMyo> ().pose == Pose.DoubleTap) {
			rotation_joint_5 = 0;
		}

		if (myo.GetComponent<ThalmicMyo> ().pose == Pose.Fist) {
			gripper = true;
		} else if (myo.GetComponent<ThalmicMyo> ().pose == Pose.FingersSpread) {
			gripper = false;
		}

		if (GameObject.Find ("Buttton:ToolFlange").GetComponent<AxisButtons> ().clicked == true) {
			if (myo.GetComponent<MyoPosition> ().z2Rot - rotation_joint_4 >= 15) {
				rotation_joint_6 = rotation_joint_6 + 0.5f;
			} else if (myo.GetComponent<MyoPosition> ().z2Rot - rotation_joint_4 <= -15) {
				rotation_joint_6 = rotation_joint_6 - 0.5f;
			}
		}
	}
}