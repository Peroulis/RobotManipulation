using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AxisSystem : MonoBehaviour
{
	private LineRenderer lr;
	public Vector3 axisOrigin;
	public float axisM;
	float arrowM = 0.1f;

	void Awake()
	{
		axisM = 50.0f;
		lr = GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Sprites/Default"));
		Vector3[] positions = new Vector3[9];

		this.transform.position = axisOrigin + new Vector3 (0, axisM*0.6f, 0);

		// axis oriantation and magnitude and position
		positions[0] = axisOrigin + new Vector3(0,axisM/2,0);
		positions[4] = axisOrigin;
		positions[5] = axisOrigin + new Vector3(axisM, 0, 0.0f);

		// axis vectors at edges
		positions[1] = positions[0] + new Vector3(-arrowM,-arrowM,0.0f);
		positions[2] = positions[1] + new Vector3(2*arrowM,0.0f,0.0f);
		positions [3] = positions [0];

		positions[6] = positions[5] + new Vector3(-arrowM,-arrowM,0.0f);
		positions[7] = positions[6] + new Vector3(0.0f,2*arrowM,0.0f);
		positions [8] = positions [5];


		lr.positionCount = positions.Length;
		lr.SetPositions(positions);

		lr.alignment = LineAlignment.Local;

		string axisTitle = this.name;
		this.GetComponent<TextMesh> ().text = axisTitle;
	}
} 
