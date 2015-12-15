using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class PlayerController : MonoBehaviour {

    public static float speed= 5;
    public static int maxHealth= 5;
	public static int maxBullets = 6;
	public static float shootSpeed = 0.5f;
	
	public int health;
	public Text text;
	public GameObject bulletPrefab;
    private Rigidbody2D rb;
	private float lastDamage, regenTime;
	public GameObject go;
	private GameController gc;
	private bool levelFinished = false;
	private float reloadTimer, reloadTime;
	public float shootTime;
	private int curBullets;
	// Use this for initialization
	void Start () {
		try{
		go =  GameObject.Find("GameController");
		gc = go.GetComponent<GameController>();
		} catch (Exception e){}
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
		health = maxHealth;
		curBullets = maxBullets;
		shootTime = -1;
	}
	// Update is called once per frame
	void Update () {
		if (health < 1) {
			gc.restart();
			Application.LoadLevel("level");
		}else if(health < maxHealth && Time.time  - lastDamage > 5){
			health++;
			lastDamage = Time.time;
		}
        float dirx = Input.GetAxis("Horizontal");
        float diry = Input.GetAxis("Vertical");
		if(Input.GetButton("Fire1") && curBullets>0 && shootTime <0){
			Debug.Log(curBullets);
			curBullets--;
			//Debug.Log("Bang");
			GameObject bullet = Instantiate(bulletPrefab);
			bullet.transform.position = this.transform.position;
			shootTime = shootSpeed;
			if(curBullets == 0){
				StartCoroutine("reload");
			}
		}
		shootTime -= Time.deltaTime;
        rb.velocity = new Vector2(dirx * speed, diry * speed);
        //this.transform.position = new Vector2(this.transform.position.x + dirx * speed, this.transform.position.y + diry * speed);
        
	}

	IEnumerator reload(){
		yield return new WaitForSeconds(2);
		curBullets = maxBullets;
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.name.Contains("zombie")){
			health--;
			lastDamage = Time.time;
		}
    }
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.name.Contains("exit") && !levelFinished){
			levelFinished = true;
			gc.nextLevel();
			Debug.Log(gc.getLevel());
			if(gc.getLevel()%5==0){
				gc.nextLevel();
				StartCoroutine("LoadBossLevel");
			}else{
				StartCoroutine("LoadNextLevel");
			}
		}
	}
	
	IEnumerator LoadNextLevel(){
		//text.text = "Level Complete";
		yield return new WaitForSeconds(2);
		Application.LoadLevel("level");
	}
	IEnumerator LoadBossLevel(){
		//text.text = "Level Complete";
		yield return new WaitForSeconds(2);
		Application.LoadLevel("boss");
	}
}
