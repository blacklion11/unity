using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public int health;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 1) {
			Application.LoadLevel("StartScene");
		}

        float dirx = Input.GetAxis("Horizontal");
        float diry = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(dirx * speed, diry * speed);
        //this.transform.position = new Vector2(this.transform.position.x + dirx * speed, this.transform.position.y + diry * speed);
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.name.Contains("zombie")){
			health--;
		}
    }
}
