using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;
	public float jumpSpeed;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public Animator	animator;
	
	private Rigidbody2D rigidbody;
	private Transform transform;
	private bool grounded;
	private int jumpCount;
	private int maxJumps;
	private bool jumpReleased;
	


	// Use this for initialization
	void Start () {

		// Stop the player from "tipping" off the edge
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.freezeRotation = true;
	
		// get player transform 
		transform = GetComponent<Transform>();

		//set default max jumps to 2
		maxJumps = 2;
		
		jumpReleased = false;
	}
	
	// Update is called once per frame
	void Update () {

		

	}

	void FixedUpdate()
	{
	
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		if(grounded)
		{		
			jumpCount = 0;
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
		}
		
		// Check for movement keys down
		if(Input.GetKey("a"))
		{
			rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
			transform.localScale = new Vector3(-1,1,1);
			animator.SetBool("walking", true);
		}
		if(Input.GetKey("d"))
		{
			rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
			transform.localScale = new Vector3(1, 1,1);
			animator.SetBool("walking", true);
		}
		
		if(Input.GetKeyDown("space"))
		{
			if(grounded || jumpCount < maxJumps)
			{
				rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
			}
		}
		else if (Input.GetKeyUp("space"))
		{
			// we have released the space bar after jumping
			jumpCount++;
		}

		// check if velocity is zero so we can stop walking
		if(Mathf.Abs(rigidbody.velocity.x) < 0.4f) animator.SetBool("walking", false);
	}
}
