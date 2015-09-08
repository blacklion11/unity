using UnityEngine;
using System.Collections;

public class CharacterMoveScript : MonoBehaviour {


	public float player_move_speed;
	
	public bool facingLeft;
	public bool jumping;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{
		if(Input.GetKey("a"))
		{
			Transform trans = GetComponent<Transform>();
			trans.position = new Vector2(trans.position.x - player_move_speed, trans.position.y);
		}
		if(Input.GetKey("d"))
		{
			Transform trans = GetComponent<Transform>();
			trans.position = new Vector2(trans.position.x + player_move_speed, trans.position.y);
		}

	}
}
