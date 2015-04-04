using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;
	private Maze mazeInstance;
	public PlayerSpawn spawnPrefab;
	private PlayerSpawn spawnInstance;
	public Torchelight torchPrefab;
	public int numTorches;
	private Torchelight[] torches;
	// Use this for initialization
	void Start () {
		//BeginGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public PlayerSpawn GetSpawn(){
		return spawnInstance;
	}

	[RPC]
	public void BeginGame(int seed) {
		Random.seed = seed;
		mazeInstance = Instantiate (mazePrefab) as Maze;
		mazeInstance.Generate ();
		MazeCell startcell = mazeInstance.GetCell (mazeInstance.RandomCoordinates);
		spawnInstance = Instantiate (spawnPrefab, startcell.transform.position, startcell.transform.rotation) as PlayerSpawn;


		for (int x =1; x>numTorches; x++) {
			MazeCell torch = mazeInstance.GetCell(mazeInstance.RandomCoordinates);
			torches[x] = Instantiate(torchPrefab , torch.transform.position, torch.transform.rotation) as Torchelight;
		}

		GetComponent<NetworkManager>().SpawnMyPlayer ();


	}

	private void RestartGame() {
//		Destroy (mazeInstance.gameObject);
//		BeginGame ();
	}
	public Maze GetMaze(){
		return mazeInstance;
	}
}
