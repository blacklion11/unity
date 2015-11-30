using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player_prefab;


	void Start () 
	{
		GameObject spawnPoint = GameObject.FindGameObjectWithTag ("player_spawn");
		GameObject player = Instantiate (player_prefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;

		Camera.main.transform.SetParent (player.transform);
	}
	
	void Update () 
	{
	
	}
}
