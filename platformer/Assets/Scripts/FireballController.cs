using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {


	bool facingLeft;
	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		this.rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Launch(bool left, float speed)
	{
		if (left)
		{
			this.transform.localScale = new Vector3(-1,1,1);
			this.rigidbody.velocity = new Vector2(speed, 0);
		}
		else 
		{
			this.transform.localScale = new Vector3(1,1,1);
			this.rigidbody.velocity = new Vector2(-speed, 0);
		}
	}
}
