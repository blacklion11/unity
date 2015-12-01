using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public string currentLevel;
	public string nextLevel;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Contains ("Player")) 
		{
			Debug.Log("Next Level..");
			Application.LoadLevel(nextLevel);
		}
	}
}
