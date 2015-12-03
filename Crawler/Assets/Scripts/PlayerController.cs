using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public int health;
	public Text text;
	public GameObject bulletPrefab;
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
		if(Input.GetButtonDown("Fire1")){
			Debug.Log("Bang");
			GameObject bullet = Instantiate(bulletPrefab);
			bullet.transform.position = this.transform.position;
		}
        rb.velocity = new Vector2(dirx * speed, diry * speed);
        //this.transform.position = new Vector2(this.transform.position.x + dirx * speed, this.transform.position.y + diry * speed);
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.name.Contains("zombie")){
			health--;
		}
    }
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.name.Contains("exit")){
			StartCoroutine("LoadNextLevel");
		}
	}
	
	IEnumerator LoadNextLevel(){
		//text.text = "Level Complete";
		yield return new WaitForSeconds(2);
		Application.LoadLevel("level");
	}
}
