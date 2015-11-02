using UnityEngine;
using System.Collections;

public class gameControlller : MonoBehaviour {
	public float spawnX, spawnY;
	public GameObject moon;
	public GameObject sun;
	public float spawnTime;
	private float spawnTimer;
	public float speed;
	private int moonCount;
	// Use this for initialization
	void Start () {
		//SpawnMoon(0,0);
		spawnTimer = spawnTime;
		speed = 10.0f;
		moonCount = 4;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		if(spawnTimer <0){
			moonCount--;
			float randy = Random.Range(-spawnY, spawnY);
			SpawnMoon(spawnX, randy);
			if(moonCount==0){
				randy = Random.Range(-spawnY, spawnY);
				SpawnSun(spawnX, randy);
				moonCount = 4;
			}
			if(spawnTime>.2){
				spawnTime*=.95f;
			}else{
				speed+=0.1f;
			}
			spawnTimer = spawnTime;
		}
		
	}
	void SpawnSun(float x, float y){
		GameObject thisSun = Instantiate(sun, new Vector3(x,y,0),Quaternion.identity) as GameObject;
		Rigidbody2D rb = thisSun.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed,0);
	}
	void SpawnMoon(float x, float y){
		GameObject thisMoon = Instantiate(moon, new Vector3(x,y,0), Quaternion.identity) as GameObject;
		Rigidbody2D rb = thisMoon.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed,0);
	}
}
