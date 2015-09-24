 using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {
	//public static GameController S;

	private Transform trans;
	private SpriteRenderer renderer;
	private Color selectColor;
	private bool isSelected;

	private Vector2 oldPos;
	private Vector2 mousePos;

	// Use this for initialization
	void Start () {

		trans = GetComponent<Transform> ();
		renderer = GetComponent<SpriteRenderer>();

		selectColor = new Color();
		selectColor.r = 0.25f;
		selectColor.g = 0.25f;
		selectColor.b = 0.25f;
		selectColor.a = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnMouseDown()
	{

		// Highlight block
		//renderer.color = selectColor;
	}

	void OnMouseDrag()
	{

	}

	void OnMouseUp()
	{
		if (!isSelected) {
			StartCoroutine(GameController.S.SelectBlock(this));
		}
	}

	public IEnumerator Select(bool val)
	{
		if(val)
		{
			renderer.color = selectColor;
		}
		else
		{
			renderer.color = Color.white;
		}

		yield return new WaitForSeconds(0);
	}
}









