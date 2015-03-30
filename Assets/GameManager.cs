using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;
	private Maze mazeInstance;
	public PlayerSpawn spawnPrefab;
	private PlayerSpawn spawnInstance;
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


	public void BeginGame() {
		mazeInstance = Instantiate (mazePrefab) as Maze;
		mazeInstance.Generate ();
		MazeCell startcell = mazeInstance.GetCell (mazeInstance.RandomCoordinates);
		spawnInstance = Instantiate (spawnPrefab, startcell.transform.position, startcell.transform.rotation) as PlayerSpawn;
	}

	private void RestartGame() {
		Destroy (mazeInstance.gameObject);
		BeginGame ();
	}
	public Maze GetMaze(){
		return mazeInstance;
	}
}
