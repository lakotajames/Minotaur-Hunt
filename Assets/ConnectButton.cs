using UnityEngine;
using System.Collections;

public class ConnectButton : MonoBehaviour {

	public GameObject connectButton;
	public GameObject roomList;
	public GUIText roomText;
	// Use this for initialization
	void Start () {

	}
	public void ConnectClick(){
		Debug.Log ("CLICKED");
		PhotonNetwork.ConnectUsingSettings ("ALPHA 0.0.2");
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnJoinedLobby(){
		Debug.Log ("LOBBY");
		//connectButton.GetComponent<Canvas>().enabled = false;
		
		PhotonNetwork.JoinRandomRoom ();
	}
	
	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
	}
	void OnJoinedRoom(){
		PhotonNetwork.LoadLevel ("Lobby");
	}


}
