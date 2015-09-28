using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
 

	public float speed;
	private Rigidbody2D paddle;
	// Use this for initialization
	void Start () {
		paddle = GetComponent<Rigidbody2D>();
		paddle.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
	

		// move the player (paddle)
		float dir = Input.GetAxis("Horizontal");
		paddle.velocity = new Vector2 (speed * dir, 0.0f);
	}
}
