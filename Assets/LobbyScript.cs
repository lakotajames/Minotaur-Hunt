using UnityEngine;
using System.Collections;

public class LobbyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.automaticallySyncScene = true;
		if (PhotonNetwork.isMasterClient) {

			PhotonNetwork.LoadLevel ("scene");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
