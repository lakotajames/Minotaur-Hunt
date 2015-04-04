using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class LobbyScript : MonoBehaviour {
	public Canvas MasterLobby;
	public InputField MinPlayerBox;
	private bool ready;
	private int minPlayers;
	// Use this for initialization
	void Start () {
		PhotonNetwork.automaticallySyncScene = true;
		bool ready = false;
		if (PhotonNetwork.isMasterClient == false) {
			MasterLobby.enabled = false;
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (ready) {
			if (MasterLobby.isActiveAndEnabled){
				MasterLobby.enabled = false;
			}
			if (PhotonNetwork.isMasterClient){
				if (PhotonNetwork.playerList.Length >= minPlayers){
					StartGame();
				}
			}
		}else{
			if (PhotonNetwork.isMasterClient && !MasterLobby.enabled == false) {
				MasterLobby.enabled = true;
			}
		}
	}
	public void StartButton(){
		minPlayers = int.Parse(MinPlayerBox.text);
		ready = true;
	}
	void StartGame(){
		PhotonNetwork.LoadLevel ("scene");
	}
}
