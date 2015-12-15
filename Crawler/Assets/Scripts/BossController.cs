using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {


	public float chargeTime;
	public float chargeTimer;
	public float spawnTime;
	public float spawnTimer;
	private ZombieController zc;
	public GameObject zombiePrefab;
	public int numMinions;
	
	// Use this for initialization
	void Start () {
		chargeTimer = 15;
		chargeTime = 5;
		spawnTimer = 8;
		spawnTime = 3;
		zc = GetComponent<ZombieController>();
		zc.speed = 4;
		zc.health = 50;
		zc.deathDelay = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
		// timer for charge attack
		if(chargeTime < 0){
			// do attack
			StartCoroutine("Spawn");
			StartCoroutine("Charge");
			chargeTime = chargeTimer;
		}
		//Debug.Log(chargeTime);
		chargeTime -= Time.deltaTime;
		if(zc.health==0){
			Debug.Log("BOSS DOWN");
			Application.LoadLevel("level");
		}
		/*
		// timer for spawning minions
		if(spawnTime < 0){
			// do attack
			StartCoroutine("Spawn");
			spawnTime = spawnTimer;
		}
		Debug.Log("Spawn time " + spawnTime);
		spawnTime -= Time.deltaTime;
		*/
	}
	
	IEnumerator Charge()
	{
		Debug.Log("Charge");
		zc.speed = 0;
		zc.rb.velocity = new Vector2(0,0);
		//StartCoroutine("Spawn");
		//Spawn();
		yield return new WaitForSeconds(2);
		zc.speed = 7;
		yield return new WaitForSeconds(2);
		zc.speed = 4;
	}
	
	IEnumerator Spawn(){
		// spawn the minions
		//GameObject[] minions = new GameObject[numMinions];
		Debug.Log("spawn");
		for(int i = 0; i < numMinions; i++)
		{
			GameObject go = Instantiate(zombiePrefab, this.transform.position, Quaternion.identity) as GameObject;
			go.GetComponent<ZombieController>().speed = 5;
			go.GetComponent<ZombieController>().agroRange = 0;
			yield return new WaitForSeconds(0.5f);
			go.GetComponent<ZombieController>().agroRange = 50;
		}
		
		
	}
}
