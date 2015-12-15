using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	Rigidbody2D rb;
	public float speed;
	public int damage;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GameObject player = GameObject.FindWithTag("Player");
		Vector3 direction = mousePos - player.transform.position;
		Vector2 bulletVelocity = new Vector2(direction.x*speed,direction.y*speed);
		rb.velocity = bulletVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
	
		if(collider.gameObject.name.Contains("zombie")){
			ZombieController zc = collider.GetComponent<ZombieController>();
			zc.Damage(damage);
			Destroy(this.gameObject);
		}else if(!collider.gameObject.name.Contains("player")){
			Destroy(this.gameObject);
		}
	}
}
