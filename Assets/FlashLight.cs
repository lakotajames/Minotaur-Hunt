using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {
	public Light flashlight;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {

			ToggleLight ();
//			flashlight.enabled = true;
//		} else {
//			flashlight.enabled = false;
		}	
	}

	void ToggleLight(){
		flashlight.enabled = !flashlight.enabled;
	}
}
