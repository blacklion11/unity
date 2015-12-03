using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {


	public int health;
	
	[SyncVar]
	public bool facingRight;
	
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
		//Debug.Log("Facing Right = " + facingRight);
	
		if(!isLocalPlayer)
		{
			// set which way the character is facing
			if(facingRight)
				transform.localScale = faceRight;
			else
				transform.localScale = faceLeft;
		
			return;
		}
		
		// get input from player
		if (Input.GetButton("Positive Move"))
		{
			if(!facingRight) CmdFlip(true);
			
			rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
		}
		else if(Input.GetButton("Negative Move"))
		{
			if(facingRight) CmdFlip(false);
			
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
		
		// set which way the character is facing
		if(facingRight)
			transform.localScale = faceRight;
		else
			transform.localScale = faceLeft;
		
	}
	
	void FixedUpdate()
	{
		if(!isLocalPlayer) return;
	}

	[Command]
	public void CmdFlip(bool facingRight)
	{
		this.facingRight = facingRight;
	}
}






























