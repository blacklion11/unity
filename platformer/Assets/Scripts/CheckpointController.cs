using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {


	public GameManager gm;

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Contains ("Player")) 
		{
			Debug.Log("Player Checkpointed");
			gm.Checkpoint();
		}
	}
}
