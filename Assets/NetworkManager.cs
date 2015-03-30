using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject standbyCamera;
	//private PlayerSpawn playerSpawn;
	private GameManager gm;
	public bool offlinemode;
	public int seed;
	// Use this for initialization
	void Start () {
		gm = GetComponent <GameManager>();
		if (offlinemode) {
			PhotonNetwork.offlineMode = true;
		}

		Connect ();
	}

	void Connect(){
		if (offlinemode){
			OnJoinedLobby();
		}else{
		PhotonNetwork.ConnectUsingSettings ("ALPHA 0.0.1");
		}
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
		if (PhotonNetwork.isMasterClient) {
			seed = Random.seed;
			gm.BeginGame();
		}
		SpawnMyPlayer ();
	}
	void SpawnMyPlayer(){
		PlayerSpawn mySpawn = gm.GetSpawn();
		GameObject MyPlayerGO = PhotonNetwork.Instantiate ("PlayerController", mySpawn.transform.position, mySpawn.transform.rotation, 0);
		standbyCamera.SetActive (false);
		(MyPlayerGO.GetComponent ("PlayerMovement") as MonoBehaviour).enabled = true;
		MyPlayerGO.GetComponent<CharacterController>().enabled = true;
		//(MyPlayerGO.GetComponent ("SimpleMouseRotator") as MonoBehaviour).enabled = true;
		((MonoBehaviour)MyPlayerGO.GetComponent("PlayerShoot")).enabled = true;
		MyPlayerGO.transform.FindChild("FirstPersonCharacter").gameObject.SetActive(true);
		MyPlayerGO.GetComponentInChildren<Camera> ().enabled = true;
		MyPlayerGO.GetComponentInChildren<AudioListener> ().enabled = true;
	}

}
