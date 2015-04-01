using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject standbyCamera;
	//private PlayerSpawn playerSpawn;
	private GameManager gm;
	public bool offlinemode;
	public int seed;
	private PhotonView pv;
	// Use this for initialization
	void Start () {
		gm = GetComponent <GameManager>();
		pv = GetComponent<PhotonView> ();
		if (PhotonNetwork.isMasterClient) {
			seed = Random.seed;
			pv.RPC("BeginGame",PhotonTargets.AllBufferedViaServer,seed);
		}
	}



	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());

	}
	
	public void SpawnMyPlayer(){
		PlayerSpawn mySpawn = gm.GetSpawn();
		GameObject MyPlayerGO = PhotonNetwork.Instantiate ("PlayerController", mySpawn.transform.position, mySpawn.transform.rotation, 0);
		standbyCamera.SetActive (false);
		(MyPlayerGO.GetComponent ("PlayerMovement") as MonoBehaviour).enabled = true;
		MyPlayerGO.GetComponent<CharacterController>().enabled = true;
		((MonoBehaviour)MyPlayerGO.GetComponent("PlayerShoot")).enabled = true;
		MyPlayerGO.transform.FindChild("FirstPersonCharacter").gameObject.SetActive(true);
		MyPlayerGO.GetComponentInChildren<Camera> ().enabled = true;
		MyPlayerGO.GetComponentInChildren<AudioListener> ().enabled = true;
	}

}
