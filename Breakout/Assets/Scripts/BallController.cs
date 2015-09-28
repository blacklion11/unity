using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    public PaddleScript paddle;
    public new CameraScript camera;
	private Rigidbody2D ball;
	public float speed;
	private Vector2 lastVelocity;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody2D> ();
        ball.transform.position = new Vector2(0, -20);
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

        if (collision.gameObject.name.Contains("paddle"))
        {
            camera.sound(1);
        }
        else if (collision.gameObject.name.Contains("brick"))
        {
            camera.sound(2);
        }

        if (ball.transform.position.y <= paddle.transform.position.y)
        {
            // YOU LOSE
            System.Threading.Thread.Sleep(2000);
            Start();
            //Application.LoadLevel("Scene1");
        }
	}
}
