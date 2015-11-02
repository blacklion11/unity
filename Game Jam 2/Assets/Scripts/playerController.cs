using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	Rigidbody2D rb;
	public float speed;
	public gameControlller gc;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float direction = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(0,speed * direction);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name.Contains("sun")){
			gc.speed-=0.25f;
			gc.spawnTime += 0.1f;
			Destroy(other.gameObject);
		}else{
			Application.LoadLevel("game");
		}
		//Application.LoadLevel("game");
	}
}
