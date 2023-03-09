using UnityEngine;
using System.Collections;

public class LiveLog  : MonoBehaviour
{
	private LineRenderer lr;
	public int pos;	
	public Vector3[] positions;
	private GameObject myo;
	public Vector3 axisposition;
	public float nextTime = 0;
	private float timeWait = 0.1f; // 0.1 = 10 Hz
	public float ampl;// = 10.0f;
	private float aqData;
	float step = 0.5f;
	public float myoRotationAxis = 0.0f;
	private float startRot = 0.0f;
	private float startGyro;
	private float ampl2 = 50;

	void Start()
	{

		myo = GameObject.Find ("Hub - 1 Myo/Myo");
		aqData = myo.transform.rotation.x;

		float M = GetComponentInParent<AxisSystem>().axisM;
		pos = 2*Mathf.RoundToInt(M); // 30
		positions = new Vector3[pos];
		ampl = M / 4.0f;
		axisposition = GetComponentInParent<AxisSystem>().axisOrigin;

		lr = GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Sprites/Default"));

		for (int j = 0; j < pos; j++) {
			
			positions[j] = axisposition + new Vector3(M + step, 0.0f, 0.0f);
		}

		lr.positionCount = positions.Length;
		lr.SetPositions(positions); 
		startRot = 0;
		nextTime = Time.time;
	}

	void Update()
	{
		if (transform.root.name == "xRotation") {
			myoRotationAxis = myo.GetComponent<MyoPosition> ().x2Rot / 10;
		} else if (transform.parent.name == "yRotation") {
			myoRotationAxis = myo.GetComponent<MyoPosition> ().y2Rot / 10;
		} else if (transform.parent.name == "zRotation") {
			myoRotationAxis = myo.GetComponent<MyoPosition> ().z2Rot / 10;
		} else if (transform.parent.name == "xGyro") {
			myoRotationAxis = myo.GetComponent<ThalmicMyo> ().gyroscope.y / (0.25f * ampl2);
		} else if (transform.parent.name == "yGyro") {
			myoRotationAxis = myo.GetComponent<ThalmicMyo> ().gyroscope.x / (0.25f * ampl2);
		} else if (transform.parent.name == "zGyro") {
			myoRotationAxis = myo.GetComponent<ThalmicMyo> ().gyroscope.z / (0.25f * ampl2);
		} else if (transform.parent.name == "xAcc") {
			myoRotationAxis = myo.GetComponent<MyoPosition> ().x2Acc * Mathf.Pow (ampl, 1);
		} else if (transform.parent.name == "yAcc") {
			myoRotationAxis = myo.GetComponent<MyoPosition> ().y2Acc * Mathf.Pow (ampl, 1);
		} else if (transform.parent.name == "zAcc") {
			myoRotationAxis = myo.GetComponent<MyoPosition> ().z2Acc * Mathf.Pow (ampl, 1);
		} else if (transform.parent.name == "xPos") {
			//myoRotationAxis = myo.GetComponent<MyoPosition> ().xPos;
		} else if (transform.parent.name == "yPos") {
			//myoRotationAxis = myo.GetComponent<MyoPosition> ().yPos;
		} else if (transform.parent.name == "zPos") {
			//myoRotationAxis = myo.GetComponent<MyoPosition> ().zPos;
		} else if (transform.parent.name == "x2Pos") {
			if (myo.transform.eulerAngles.x > 180) {
				myoRotationAxis = (myo.transform.eulerAngles.x - 360);
			} else
				myoRotationAxis = myo.transform.eulerAngles.x / 10;
		} else if (transform.parent.name == "y2Pos") {
			if (myo.transform.eulerAngles.y > 180) {
				myoRotationAxis = (myo.transform.eulerAngles.y - 360) / 10;
			} else
				myoRotationAxis = myo.transform.eulerAngles.y / 10;
		} else if (transform.parent.name == "z2Pos") {
			if (myo.transform.eulerAngles.z > 180) {
				myoRotationAxis = (myo.transform.eulerAngles.z - 360) / 10;
			} else
				myoRotationAxis = myo.transform.eulerAngles.z / 10;
		} else if (transform.parent.name == "IsolateX") {
			myoRotationAxis = myo.GetComponent<RotationIsolation> ().x4Rot/10;
		}else if (transform.parent.name == "IsolateY") {
			myoRotationAxis = myo.GetComponent<RotationIsolation> ().y4Rot/10;
		}else if (transform.parent.name == "IsolateZ") {
			myoRotationAxis = myo.GetComponent<RotationIsolation> ().z4Rot/10;
		}
			
		if (Time.time >= nextTime) {
			positions [pos - 1].y = axisposition.y + myoRotationAxis - startRot; 
				
			for (int j = 1 ; j < pos ; j++){
				positions [j - 1] = positions [j] - new Vector3(step,0.0f,0.0f);
			}
			lr.SetPositions(positions); 
			nextTime += timeWait;
		}
	}

}