 using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	private Transform trans;
	private SpriteRenderer renderer;
	private Color selectColor;
	private Color deselectColor;
	private bool isSelected;

	private Vector2 oldPos;
	private Vector2 mousePos;
	private int id;
	private int color_id;
	public bool counted;

	// Use this for initialization
	void Start () {

		trans = GetComponent<Transform> ();
		renderer = GetComponent<SpriteRenderer>();

		selectColor = new Color();
		selectColor.r = 0.25f;
		selectColor.g = 0.25f;
		selectColor.b = 0.25f;
		selectColor.a = 1f;

		deselectColor = new Color();
		deselectColor.r = 1f;
		deselectColor.g = 1f;
		deselectColor.b = 1f;
		deselectColor.a = 1f;

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
			StartCoroutine(GameController.S.SelectBlock(this, true));
		}
		else
		{
			StartCoroutine(GameController.S.SelectBlock(this,false));
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
			renderer.color = deselectColor;
		}

		yield return new WaitForSeconds(0);
	}

	public int ID
	{ 
		get { return id;}
		set { id = value;}
	}	

	public int Color_ID
	{
		get { return color_id; }
		set { color_id = value; }

	}
}









