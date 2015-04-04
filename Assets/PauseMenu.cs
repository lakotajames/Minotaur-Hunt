using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public Canvas PauseMenuCanvas;
	public Canvas Crosshair;
	private GameObject PlayerObject;

	public void ResumeButtonClick(){
		PauseMenuCanvas.enabled = false;
		Crosshair.enabled = true;
		Cursor.visible = false;
	}
	void Start(){
		PauseMenuCanvas.enabled = false;
		Cursor.visible = false;
	}

	public void QuitButtonClick() {
		Application.Quit();
	}
	void Update(){
		if (Input.GetButtonDown ("Cancel")) {
			// Player wants Pause.
			PauseMenuCanvas.enabled = ! PauseMenuCanvas.enabled;
			Crosshair.enabled = ! Crosshair.enabled;
			Cursor.visible =! Cursor.visible;
			if (PlayerObject != null){
//				(PlayerObject.GetComponent("SimpleMouseRotator") as MonoBehaviour).enabled =! (PlayerObject.GetComponent("SimpleMouseRotator") as MonoBehaviour).enabled;
			}
		}
	}
	public void GetPlayerObject(GameObject PO){
		PlayerObject = PO;
	}

	public void MouseSliderChanged(){
		if (PlayerObject != null) {
//			(PlayerObject.GetComponent("SimpleMouseRotator") as MonoBehaviour)
		}
	}
}
