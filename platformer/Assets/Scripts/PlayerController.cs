using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float move_speed;
	public float jump_force;


	// Use this for initialization
	void Start () {

		// Stop the player from "tipping" off the edge
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		//Get player transform
		Transform t = GetComponent<Transform>();

		//Get player rigidbody
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		// Check for movement keys down
		if(Input.GetKey("a"))
		{
			t.position = new Vector2(t.position.x - move_speed, t.position.y);
		}
		if(Input.GetKey("d"))
		{
			t.position = new Vector2(t.position.x + move_speed, t.position.y);
		}
		if(Input.GetKey("space"))
		{
			rb.AddForce(new Vector2(0, jump_force));
		}
	}
}
