using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject standbyCamera;
	public PlayerSpawn playerSpawn;
	// Use this for initialization
	void Start () {
		Connect ();
	}

	void Connect(){
		PhotonNetwork.ConnectUsingSettings ("ALPHA 0.0.1");
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		SpawnMyPlayer ();
	}
	void SpawnMyPlayer(){
		PlayerSpawn mySpawn = playerSpawn;
		GameObject MyPlayerGO = PhotonNetwork.Instantiate ("PlayerController", mySpawn.transform.position, mySpawn.transform.rotation, 0);
		standbyCamera.SetActive (false);
		(MyPlayerGO.GetComponent ("PlayerMovement") as MonoBehaviour).enabled = true;
		MyPlayerGO.GetComponent<CharacterController>().enabled = true;
		MyPlayerGO.GetComponent<MouseControl>().enabled = true;
		MyPlayerGO.GetComponentInChildren<MouseControl>().enabled = true;
		MyPlayerGO.GetComponentInChildren<Camera> ().enabled = true;
		MyPlayerGO.GetComponentInChildren<AudioListener> ().enabled = true;
	}

}
