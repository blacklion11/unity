using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	private GameObject player;
	public Rigidbody2D rb;
	public float agroRange;
	public float zombieWanderTime;
	private float zombieTimer;
	public float speed;
	public int health;
	public float deathDelay=0;
	
	// Use this for initialization
	void Start () {
		while(player==null){
			Debug.Log("Looking for player");
			player =  GameObject.Find("player");
		}
		if(Vector3.Distance(this.transform.position, player.transform.position) <= agroRange)
		{
			Destroy(this.gameObject);
		}
		
		rb = GetComponent<Rigidbody2D>();
		zombieTimer = -1;
		speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		Vector3 playerTransform = new Vector3(player.transform.position.x,player.transform.position.y,0);
		if(Vector3.Distance(playerTransform, this.transform.position) < agroRange){
			Move(playerTransform, speed * Time.deltaTime);
			zombieTimer = -1;
		}else if(zombieTimer < 0){
			zombieTimer = zombieWanderTime;
			/*int ydir = Random.Range(-1, 1);
			int xdir = Random.Range(-1, 1);
			Vector3 lookdir = new Vector3(0,0,0);
			transform.rotation = Quaternion.LookRotation(lookdir);*/
			rb.velocity = new Vector2(0,0);
			Vector2 force = new Vector2(100*Random.Range(-1f,1f),100*Random.Range(-1f,1f));
			//Debug.Log(force);
			rb.AddForce(force);
		}else{
			zombieTimer -= Time.deltaTime;
		}
		
	}

	
	public void Damage(int damage)
	{
		Debug.Log(health);
		health -= damage;
		if(health <= 0)
		{
			StartCoroutine("die");
		}
	}
	
	IEnumerator die(){
		yield return new WaitForSeconds(deathDelay);
		Destroy(this.gameObject);
	}
	
	private void Move(Vector3 pos, float speed)
	{
		transform.position= Vector3.MoveTowards(transform.position, pos, speed);
	}
}
