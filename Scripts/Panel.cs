using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {

	private Text txt;
	private string write;
	private string j;

	void Start () {
		txt = gameObject.GetComponent<Text> ();
		j = txt.text.Substring (6, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (j == "1") {
			write = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().rotation_joint_1.ToString();
		} else if (j == "2") {
			write = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().rotation_joint_2.ToString();
		}else if (j == "3") {
			write = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().rotation_joint_3.ToString();
		}else if (j == "4") {
			write = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().rotation_joint_4.ToString();
		}else if (j == "5") {
			write = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().rotation_joint_5.ToString();
		}else if (j == "6") {
			write = GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().rotation_joint_6.ToString();
		}

		txt.text = "Joint " + j + ": " + write;
	}
}
