using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {


	public int health;
	
	public float walkSpeed;
	public float runSpeed;
	public float jumpSpeed;

	private Rigidbody2D rb;
	private Transform transform;
	private Vector3 faceRight;
	private Vector3 faceLeft;

	void Start () 
	{
		this.rb = GetComponent<Rigidbody2D>();
		this.transform = GetComponent<Transform>();
		
		faceRight = new Vector3(1,1,1);
		faceLeft = new Vector3(-1,1,1);
	}
	
	void Update () 
	{
		if(!isLocalPlayer) return;
		
		// get input from player
		if (Input.GetButton("Positive Move"))
		{
			transform.localScale = faceRight;
			rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
		}
		else if(Input.GetButton("Negative Move"))
		{
			transform.localScale = faceLeft;
			rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
		}
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
		
		if(Input.GetButtonDown("Jump"))
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
		}
		
	}
	
	void FixedUpdate()
	{
		if(!isLocalPlayer) return;
	}
	
}
