using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player_prefab;
	public GameObject zombie1_prefab;
	public GameObject zombie2_prefab;

	private bool checkPointed;


	void Awake()
	{
		//DontDestroyOnLoad (this.gameObject);
	}

	void Start () 
	{

		checkPointed = false;
		SpawnPlayer ();


		GameObject[] spawns = GameObject.FindGameObjectsWithTag ("zombie1_spawn");
		for(int i = 0 ; i < spawns.Length; i++)
		{
			GameObject mob = Instantiate( zombie1_prefab, spawns[i].transform.position, Quaternion.identity) as GameObject;
		}


		spawns = GameObject.FindGameObjectsWithTag ("zombie2_spawn");
		for(int i = 0 ; i < spawns.Length; i++)
		{
			GameObject mob = Instantiate( zombie2_prefab, spawns[i].transform.position, Quaternion.identity) as GameObject;
		}


	}
	
	void Update () 
	{
	
	}

	public void Checkpoint()
	{
		checkPointed = true;
	}

	public void SpawnPlayer()
	{
		if (!checkPointed) 
		{
			GameObject spawnPoint = GameObject.FindGameObjectWithTag ("player_spawn");
			GameObject player = Instantiate (player_prefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
			GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			camera.transform.SetParent (player.transform);
			camera.transform.localPosition = new Vector3 (0, 0, -10);
		} 
		else
		{
			GameObject spawnPoint = GameObject.FindGameObjectWithTag ("checkpoint");
			GameObject player = Instantiate (player_prefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
			GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			camera.transform.SetParent (player.transform);
			camera.transform.localPosition = new Vector3 (0, 0, -10);
		}
	}
}
