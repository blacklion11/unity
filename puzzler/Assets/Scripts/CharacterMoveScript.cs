using UnityEngine;
using System.Collections;

public class CharacterMoveScript : MonoBehaviour {


	public float player_move_speed;
	
	private bool facingLeft;
	private bool jumping;
	private bool grounded;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{
		if(Input.GetKey("a"))
		{
			Transform trans = GetComponent<Transform>();
			trans.position = new Vector2(trans.position.x - player_move_speed, trans.position.y);
		}
		if(Input.GetKey("d"))
		{
			Transform trans = GetComponent<Transform>();
			trans.position = new Vector2(trans.position.x + player_move_speed, trans.position.y);
		}
		if (Input.GetKey ("space"))
		{
			Jump ();
		}

	}

	void Jump()
	{
		grounded = true;
		if (grounded)
		{
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			rb.AddForce( new Vector2(0, 100));
		}
	}















}
