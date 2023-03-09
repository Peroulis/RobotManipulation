using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour {

	private LineRenderer lr;
	private Vector3[] pos;
	private Vector3 axisOrigin;

	private float maxV,minV;
	private Vector3 maxPos,minPos;
	public float realMaxV, realMinV;

	private float M;

	void Start () {
		axisOrigin = GetComponentInParent<AxisSystem> ().axisOrigin;
		lr = this.GetComponent<LineRenderer> ();
		pos = new Vector3[4];
		M = GetComponentInParent<AxisSystem> ().axisM * 2;
		lr.material = new Material(Shader.Find("Sprites/Default"));
		lr.SetColors (new Color(180,170,0),new Color(180,170,0));
	}
	
	// Update is called once per frame
	void Update () {
		minV = +100;
		maxV = -100;
		for (int i = 0 ; i < M ; i++){

			if (GetComponentInParent<LiveLog> ().positions [i].y > maxV) {
				maxV = GetComponentInParent<LiveLog> ().positions [i].y;
				pos [0] = new Vector3 (GetComponentInParent<LiveLog> ().positions [i].x,maxV, 0.0f);
				pos [1] = new Vector3 (axisOrigin.x, maxV, 0.0f);
				realMaxV = maxV*10-200;
			}
			if (GetComponentInParent<LiveLog> ().positions [i].y < minV) {
				minV = GetComponentInParent<LiveLog> ().positions [i].y;
				pos [2] = new Vector3 (axisOrigin.x, minV, 0.0f);// + axisOrigin;
				pos [3] = new Vector3 (GetComponentInParent<LiveLog> ().positions [i].x, minV, 0.0f);// + axisOrigin;
				realMinV = minV*10-200;
			}
		}
		lr.positionCount = pos.Length;
		lr.SetPositions(pos);
		lr.alignment = LineAlignment.Local;
	}
}