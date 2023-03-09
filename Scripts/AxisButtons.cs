using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AxisButtons : MonoBehaviour{

	private Button button;
	public bool clicked;
	private ColorBlock clr;

	void Start(){
		button = this.GetComponent<Button> ();

		if (this.name == "Buttton:Shoulder") {
			clicked = true;
		} else if (button.name == "Buttton:Arm") {
			clicked = true;
		} else if (button.name == "Buttton:Elbow") {
			clicked = false;
		} else if (button.name == "Buttton:Forearm") {
			clicked = true;
		} else if (button.name == "Buttton:Wrist") {
			clicked = false;
		} else if (button.name == "Buttton:ToolFlange") {
			clicked = false;
		} else {
			clicked = false;
		}
			
		clr = button.colors;
		if (clicked == true) {
			clr.normalColor = Color.yellow;
			clr.highlightedColor = Color.yellow;
		} else {
			clr.disabledColor = Color.gray;
			clr.normalColor = Color.gray;
			clr.highlightedColor = Color.gray;
		}
		button.colors = clr;
		button.onClick.AddListener (Task);
	}

	void Update(){
		
		if (clicked == true) {
			clr.highlightedColor = Color.yellow;
			clr.disabledColor = Color.red;
			clr.normalColor = Color.yellow;
			button.colors = clr;
		} else {
			clr.highlightedColor = Color.gray;
			clr.disabledColor = Color.gray;
			clr.normalColor = Color.gray;
			button.colors = clr;
		}

		if (GameObject.Find ("Staubli").GetComponent<StaubliMovement> ().gripper == true) {
			GameObject.Find ("Buttton:Wrist").GetComponent<AxisButtons> ().clicked = true;
		} else GameObject.Find ("Buttton:Wrist").GetComponent<AxisButtons> ().clicked = false;
	}

	void Task(){  
		if (clicked == true) {
			if (this.name == "Buttton:Elbow") {
				GameObject.Find ("Buttton:Arm").GetComponent<AxisButtons> ().clicked = true;
			} else if (this.name == "Buttton:Arm") {
				GameObject.Find ("Buttton:Elbow").GetComponent<AxisButtons> ().clicked = true;
			}

			if (this.name == "Buttton:ToolFlange") {
				GameObject.Find ("Buttton:Forearm").GetComponent<AxisButtons> ().clicked = true;
			} else if (this.name == "Buttton:Forearm") {
				GameObject.Find ("Buttton:ToolFlange").GetComponent<AxisButtons> ().clicked = true;
			}

			clicked = false;

			clr.highlightedColor = Color.gray;
			clr.disabledColor = Color.gray;
			clr.normalColor = Color.gray;
		} else {
			if (this.name == "Buttton:Elbow") {
				GameObject.Find ("Buttton:Arm").GetComponent<AxisButtons> ().clicked = false;
			} else if (this.name == "Buttton:Arm") {
				GameObject.Find ("Buttton:Elbow").GetComponent<AxisButtons> ().clicked = false;
			}

			if (this.name == "Buttton:ToolFlange") {
				GameObject.Find ("Buttton:Forearm").GetComponent<AxisButtons> ().clicked = false;
			} else if (this.name == "Buttton:Forearm") {
				GameObject.Find ("Buttton:ToolFlange").GetComponent<AxisButtons> ().clicked = false;
			}


			clicked = true;
			clr.highlightedColor = Color.yellow;
			clr.disabledColor = Color.red;
			clr.normalColor = Color.yellow;
		}
			button.colors = clr;
	}
}