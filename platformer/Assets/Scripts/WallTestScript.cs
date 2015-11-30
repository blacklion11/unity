using UnityEngine;
using System.Collections;

public class WallTestScript : MonoBehaviour {

	public bool isColliding;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log (collision.gameObject.tag);
		isColliding = collision.gameObject.tag.Contains ("ground");
	}

}
