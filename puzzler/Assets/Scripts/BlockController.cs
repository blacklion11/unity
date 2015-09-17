using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {


	private Transform trans;

	private Vector2 oldPos;

	// Use this for initialization
	void Start () {

		trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnMouseDown()
	{

		// Pick up block

	}

	void OnMouseDrag()
	{

		// Drag the block
		Vector2 pos = new Vector2 (oldPos.x - Input.mousePosition.x, oldPos.y - Input.mousePosition.y);

		trans.position = oldPos = pos;
	}

	void OnMouseUp()
	{
		// Check where the block was dropped
	}
}
