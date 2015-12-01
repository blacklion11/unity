using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;
	public float jumpSpeed;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public Animator	animator;
	public GameObject fireballPrefab;
	public float fireballSpeed;
	
	private Rigidbody2D rigidbody;
	private Transform transform;
	private bool grounded;
	private int jumpCount;
	private int maxJumps;
	private bool jumpReleased;
	private bool stunned;
	private float stunTime;
	private float stunTimer;

	


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
		if (!stunned) {
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
			animator.SetBool("grounded", grounded);

			if (grounded) {		
				jumpCount = 0;
				//rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
			}
		
			// Check for movement keys down
			if (Input.GetKey (KeyCode.A)) {
				rigidbody.velocity = new Vector2 (-moveSpeed, rigidbody.velocity.y);
				transform.localScale = new Vector3 (-1, 1, 1);
				animator.SetBool ("walking", true);
			}
			if (Input.GetKey (KeyCode.D)) {
				rigidbody.velocity = new Vector2 (moveSpeed, rigidbody.velocity.y);
				transform.localScale = new Vector3 (1, 1, 1);
				animator.SetBool ("walking", true);
			}
		
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (grounded || jumpCount < maxJumps) {
					rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed);
				}
			} else if (Input.GetKeyUp (KeyCode.Space)) {
				// we have released the space bar after jumping
				jumpCount++;
			}
			if(Input.GetKeyDown(KeyCode.Return))
			{
				if(transform.localScale == new Vector3(1,1,1))
				{
					//Debug.Log("Facing Right");
					// facing right
					GameObject fireball = Instantiate(fireballPrefab, new Vector2(this.transform.position.x + .5f, this.transform.position.y), Quaternion.identity) as GameObject;
					fireball.GetComponent<FireballController>().Launch(false, fireballSpeed);
					//fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(fireballSpeed, 0);
					//fireball.transform.localScale = this.transform.localScale;
				}
				else
				{
					// facing left
					GameObject fireball = Instantiate(fireballPrefab, new Vector2(this.transform.position.x - .5f, this.transform.position.y), Quaternion.identity) as GameObject;
					fireball.GetComponent<FireballController>().Launch(true, fireballSpeed);
					//fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireballSpeed, 0);
					//fireball.transform.localScale = this.transform.localScale;
				}

			}

			// check if velocity is zero so we can stop walking
			if (Mathf.Abs (rigidbody.velocity.x) < 0.4f)
				animator.SetBool ("walking", false);
			// check if lateral movement keys are let up to stop moving
			if (!(Input.GetKey ("a") || Input.GetKey ("d")))
				rigidbody.velocity = new Vector2 (0, rigidbody.velocity.y);
		} 
		else
		{
			if(stunTimer < stunTime)
			{
				stunTimer += 1;
			}
			else
			{
				stunned = false;
			}

		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag.Contains("enemy"))
		{
			GetComponent<HealthController>().Hit(collision.collider.GetComponent<DamageController>().GetDamage());
		}
	}

	public void Stun(float stunTime)
	{
		this.stunned = true;
		this.stunTime = stunTime;
		this.stunTimer = 0;
	}

}











