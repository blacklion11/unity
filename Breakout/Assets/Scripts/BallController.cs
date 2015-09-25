using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private Rigidbody2D ball;
	public float speed;
	private Vector2 lastVelocity;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody2D> ();
		float dirx = 0;
		while(Mathf.Abs(dirx) < 1)
		{
			dirx = Random.Range (-3, 3);
		}
		float diry = Random.Range (1, 3);
		ball.velocity = new Vector2 (speed * dirx, speed * diry);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		lastVelocity = ball.velocity;

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		ball.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);

	}
}
