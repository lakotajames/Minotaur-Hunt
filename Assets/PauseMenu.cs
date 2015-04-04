using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public Canvas PauseMenuCanvas;
	public Canvas Crosshair;

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
		}
	}
}
