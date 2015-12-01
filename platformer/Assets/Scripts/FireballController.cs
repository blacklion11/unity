using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {


	bool facingLeft;
	private Rigidbody2D rigidbody;

	void Awake()
	{
		this.rigidbody = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag.Contains("enemy"))
		{
			other.GetComponent<HealthController>().Hit(1);
		}
		if(!other.gameObject.tag.Contains("player")) Destroy (this.gameObject);
	}

	public void Launch(bool left, float speed)
	{
		if (left)
		{
			this.transform.localScale = new Vector3(-1,1,1);
			this.rigidbody.velocity = new Vector2(-speed, 0);
		}
		else 
		{
			this.transform.localScale = new Vector3(1,1,1);
			this.rigidbody.velocity = new Vector2(speed, 0);
		}
	}
}
