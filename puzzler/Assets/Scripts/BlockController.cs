using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {


	private Transform trans;

	private Vector2 oldPos;
	private Vector2 mousePos;

	// Use this for initialization
	void Start () {

		trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnMouseDown()
	{

		// Get Mouse Coords
		mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		// Pick up block

	}

	void OnMouseDrag()
	{

		// Drag the block
		Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

		// divide delta by 32 to get pixels (not units)
		float deltaX = (pos.x - mousePos.x) / 32;
		float deltaY = (pos.y - mousePos.y) / 32;

		if(deltaX != 0 || deltaY != 0)
		{
		
			trans.position = new Vector2(trans.position.x + deltaX, trans.position.y + deltaY);
			mousePos = pos;
		}
	}

	void OnMouseUp()
	{
		// Check where the block was dropped
		float dropPosX = trans.position.x;
		float dropPosY = trans.position.y;

		int tileX = (int) dropPosX / 32;
		int tileY = (int) dropPosY / 32;

		Debug.Log(dropPosX + ", " + dropPosY);

	}
}
