using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public float moveSpeed = 2f;
	public bool facingLeft;
	public GameObject wallTest;
	public WallTestScript wts;
	public float knockBackForce;


	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		this.rigidbody = GetComponent<Rigidbody2D> ();
		facingLeft = true;

		rigidbody.velocity = new Vector2 (-moveSpeed, rigidbody.velocity.y);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void FixedUpdate()
	{
		if (wts.isColliding) 
		{
			//was traveling left
			if(facingLeft)
			{
				rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
				transform.localScale = new Vector3(-1,1,1);
			}
			else // was traveling right
			{
				rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
				transform.localScale = new Vector3(1,1,1);
			}
			facingLeft = !facingLeft;

			wts.isColliding = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		// if we collide with the player...
		if (collision.gameObject.name.Contains ("Player")) 
		{
			Debug.Log("Collidied With Player");
			rigidbody.velocity = facingLeft ?  new Vector2(-moveSpeed, rigidbody.velocity.y) : rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);

			if(collision.gameObject.transform.position.x < this.transform.position.x)
			{
				collision.gameObject.GetComponent<PlayerController>().Stun(10);
				collision.rigidbody.velocity = new Vector2(-knockBackForce, collision.rigidbody.velocity.y);
			}
			else
			{
				collision.gameObject.GetComponent<PlayerController>().Stun(10);
				collision.rigidbody.velocity = new Vector2(knockBackForce, collision.rigidbody.velocity.y);
			}

			collision.gameObject.GetComponent<HealthController>().Hit(GetComponent<DamageController>().GetDamage());
		}

	}
}
