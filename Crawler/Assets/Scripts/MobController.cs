using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {


	public GameObject mobPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SpawnMob(int id, int x, int y)
	{
		GameObject mob = Instantiate(mobPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
		
	}
}
