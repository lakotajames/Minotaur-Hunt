using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public Canvas PauseMenuCanvas;
	public Canvas Crosshair;
	// Use this for initialization
	public void ResumeButtonClick(){
		PauseMenuCanvas.enabled = false;
		Crosshair.enabled = true;
	}
	void Start(){
		PauseMenuCanvas.enabled = false;
	}
	// Update is called once per frame
	public void QuitButtonClick() {
		Application.Quit();
	}
	void Update(){
		if (Input.GetButtonDown("Cancel")) {
			// Player wants Pause.
			PauseMenuCanvas.enabled =! PauseMenuCanvas.enabled;
			Crosshair.enabled =! Crosshair.enabled;
		}
	}
}
