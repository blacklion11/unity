using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player_prefab;


	void Start () 
	{
		GameObject spawnPoint = GameObject.FindGameObjectWithTag ("player_spawn");
		GameObject player = Instantiate (player_prefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;

		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		camera.transform.SetParent (player.transform);
		camera.transform.localPosition = new Vector3 (0, 0, -10);
	}
	
	void Update () 
	{
	
	}
}
