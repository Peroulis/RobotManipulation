using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using M = UnityEngine.Mathf;//();


public class MyoAxis : MonoBehaviour {

	private LineRenderer xAxis;
	private LineRenderer yAxis;
	private LineRenderer zAxis;
	public Vector3 MyoAxisOrigin = new Vector3(0.0f,0.0f,0.0f);

	private Vector3[] xpos = new Vector3[2];
	private Vector3[] ypos = new Vector3[2];
	private Vector3[] zpos = new Vector3[2];

	private float axisM = 10.0f;
	//private float xAngle = 0 ;
	//private float yAngle = 0 ;
	//private float zAngle = 0 ;
	//float arrowM = 0.1f;
	public Matrix4x4 matrix = new Matrix4x4();

	public Vector4 m;

	void Awake () {
		xAxis = this.transform.Find("xAxis").GetComponent<LineRenderer> ();
		yAxis = this.transform.Find("yAxis").GetComponent<LineRenderer> ();
		zAxis = this.transform.Find("zAxis").GetComponent<LineRenderer> ();

		xAxis.material = new Material(Shader.Find("Sprites/Default"));
		yAxis.material = new Material(Shader.Find("Sprites/Default"));
		zAxis.material = new Material (Shader.Find ("Sprites/Default"));
		matrix = Matrix4x4.identity;
		matrix.SetColumn (3,matrix * new Vector4 (10, 0, 0, 1)); // translation by x = 10
		//matrix.SetColumn (3,matrix * new Vector4 (0, 10, 0, 1)); // translation by y = 10
		//matrix = matrix*matrix; // translation by x = y = 10
		//Matrix4x4 rot = new Matrix4x4();
		/*
		rot.SetRow (0, new Vector4 (1, 0, 0, 0));
		rot.SetRow (1, new Vector4 (0, Mathf.Cos(45.0f*Mathf.Deg2Rad), -Mathf.Sin(45.0f*Mathf.Deg2Rad), 0));
		rot.SetRow (2, new Vector4 (0, Mathf.Sin(45.0f*Mathf.Deg2Rad), Mathf.Cos(45.0f*Mathf.Deg2Rad), 0));
		rot.SetRow (3, new Vector4 (0, 0, 0, 1)); 
		matrix = matrix * rot;

		//matrix = Matrix4x4.Translate(new Vector3 (10.0f,0.0f,0.0f));
		//matrix = Matrix4x4.Translate(new Vector3 (10.0f,0.0f,0.0f));
		//matrix.SetTRS (new Vector3 (10.0f, 0.0f, 0.0f), Quaternion.Euler(1.0f, 1.0f, 1.0f), new Vector3 (0.0f, 0.0f, 0.0f));
		//matrix.SetRow (0, new Vector4 (1, 0, 0, MyoAxisOrigin.x));
		//matrix.SetRow (1, new Vector4 (0, 1, 0, MyoAxisOrigin.y));
		//matrix.SetRow (2, new Vector4 (0, 0, 1, MyoAxisOrigin.z));
		//matrix.SetRow (3, new Vector4 (0, 0, 1, 1));
		Debug.Log(matrix);
		*/
		xpos [0] = matrix.GetColumn (3);
		xpos [1] = MyoAxisOrigin + new Vector3 (axisM, 0, 0);
		xAxis.positionCount = xpos.Length;
		xAxis.SetPositions(xpos); 

		ypos [0] = matrix.GetColumn (3);
		ypos [1] = MyoAxisOrigin + new Vector3 (0, axisM, 0);
		yAxis.positionCount = ypos.Length;
		yAxis.SetPositions(ypos); 

		zpos [0] = matrix.GetColumn (3);
		zpos [1] = MyoAxisOrigin + new Vector3 (0, 0, axisM);
		zAxis.positionCount = zpos.Length;
		zAxis.SetPositions(zpos); 

	}
	

	void Update () {

	}
}
