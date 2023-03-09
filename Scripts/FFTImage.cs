using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B83.MathHelpers;

public class FFTImage : MonoBehaviour {
	public Complex[] spec = new Complex[16];
	private LineRenderer lr15;
	public Vector3[] pos15;
	public GameObject FLine;

	void Start(){
		pos15 = new Vector3[16];
		lr15 = this.GetComponent<LineRenderer>();
		lr15.material = new Material(Shader.Find("Sprites/Default"));
		FLine = GameObject.Find ("LR_2");
	}

	void Update(){
		for (int i = 0; i < 16; i++) {
			//float p = GetComponentInParent<LiveLog> ().positions [i].y;
			//Debug.Log (p);
			spec [i].real = GetComponentInParent<LiveLog> ().positions [i].y;
			spec [i].img = 0.0f;
		}
		FFT.CalculateFFT (spec, false);
		for (int i = 0; i < spec.Length / 2; i++) {
			Debug.DrawLine (new Vector3 (i, 4), new Vector3 (i, 4 + (float)spec [i].magnitude * 20), Color.white);
		}
		/*
		for (int i = 0; i < spec.Length ; i = i + 2) {
			pos15 [i] = new Vector3 (i + 18, 2.0f, 0.0f);
			pos15 [i + 1] = new Vector3 (i + 18, 2.0f + (float)spec [i].magnitude * 2, 0.0f);
			lr15.SetPosition (0,pos15 [i]);
			lr15.SetPosition (1,pos15 [i+1]);
			}
			*/
	}
}