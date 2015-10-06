using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;

	public Transform citySpot1, citySpot2, citySpot3, citySpot4, citySpot5, citySpot6;
	public GameObject cityPrefab;
 
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode); 

		initCities();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void initCities()
	{
		Vector3 spawnPos = new Vector3(citySpot1.position.x, citySpot1.position.y, 0);
		GameObject go = Instantiate(cityPrefab, spawnPos, Quaternion.identity) as GameObject;
		go.transform.parent = citySpot1;

		spawnPos = new Vector3(citySpot2.position.x, citySpot2.position.y, 0);
		go = Instantiate(cityPrefab, spawnPos, Quaternion.identity) as GameObject;
		go.transform.parent = citySpot2;

		spawnPos = new Vector3(citySpot3.position.x, citySpot3.position.y, 0);
		go = Instantiate(cityPrefab, spawnPos, Quaternion.identity) as GameObject;
		go.transform.parent = citySpot3;

		spawnPos = new Vector3(citySpot4.position.x, citySpot4.position.y, 0);
		go = Instantiate(cityPrefab, spawnPos, Quaternion.identity) as GameObject;
		go.transform.parent = citySpot4;

		spawnPos = new Vector3(citySpot5.position.x, citySpot5.position.y, 0);
		go = Instantiate(cityPrefab, spawnPos, Quaternion.identity) as GameObject;
		go.transform.parent = citySpot5;

		spawnPos = new Vector3(citySpot6.position.x, citySpot6.position.y, 0);
		go = Instantiate(cityPrefab, spawnPos, Quaternion.identity) as GameObject;
		go.transform.parent = citySpot6;
	}
}
