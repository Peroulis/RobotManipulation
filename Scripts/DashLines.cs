using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashLines : MonoBehaviour {

	private LineRenderer lr;
	private LineRenderer lr2;
	private Vector3 axisOrigin;
	GameObject prefab;
	GameObject prefab2;
	public Vector3[] pos2 = new Vector3[Mathf.RoundToInt(2)];

	void Awake () {
		prefab = Resources.Load<GameObject> ("LR_1");
		prefab2 = Resources.Load<GameObject> ("LR_2");

		axisOrigin = GetComponentInParent<AxisSystem> ().axisOrigin;
		float M = GetComponentInParent<AxisSystem>().axisM;
		float div = 1f;

		Vector3[] pos = new Vector3[Mathf.RoundToInt(M)];

		pos[0] = axisOrigin;

		for (float k = div; k < M/2 ; k = k + div) {
			for (int i = 1; i < M ; i++) {
				pos [i].x = div + pos [i - 1].x;
				pos [i].y = axisOrigin.y + k;
				pos [i].z = axisOrigin.z;
			}


			for (int i = 1; i < M; i++) {
				if ((i + 1) % 2 == 0) {
					pos2 [0] = pos [i - 1];
					pos2 [1] = pos [i];
					instLine (1, pos2 [0], pos2 [1]);
				} else {
					pos2 [0] = pos [i - 1];
					pos2 [1] = pos [i];
					instLine (2, pos2 [0], pos2 [1]);
				}
			}
		}
	}
	
	void instLine(int pr,Vector3 start, Vector3 end){
		if (pr == 1) {
			Instantiate (prefab, transform);
		} else {
			Instantiate (prefab2, transform);
		}
		lr = prefab.GetComponent<LineRenderer> ();
		lr.material = new Material(Shader.Find("Sprites/Default"));
		Vector3[] pos3 = new Vector3[2];
		pos3 [0] = start;
		pos3 [1] = end;
		lr.positionCount = pos3.Length;
		lr.SetPositions (pos3);
		lr.alignment = LineAlignment.Local;
	}
}
