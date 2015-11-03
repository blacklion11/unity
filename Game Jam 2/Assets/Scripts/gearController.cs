using UnityEngine;
using System.Collections;

public class gearController : MonoBehaviour {

	public Camera pauseCamera;


	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(1f,1f,1f,.5f);

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 touchPos = Input.GetTouch(0).position;
		if(touchPos.y < (this.transform.position.y - 50) && touchPos.x > (this.transform.position.x - 50))
		{
			pauseCamera.enabled = true;
		}
	}
}
