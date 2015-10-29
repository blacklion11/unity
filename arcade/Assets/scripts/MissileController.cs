using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {


	public GameObject[] cities;
	public float speed;

	private Transform targetPos;

	private bool isEnemy;
	private int targetCity;

	// Use this for initialization
	void Start () {
		// find all the cities
		cities = new GameObject[6];
		for(int i = 0; i < 6; i++)
		{
			cities[i] = GameObject.Find("CitySpot" + (i+1));
		}

		targetPos = null;


	}

	void Awake(){}

	void FixedUpdate()
	{
		// travel towards the target city position
		while(targetPos != null)
		{
			transform.position = Vector2.MoveTowards(this.transform.position, targetPos.position, speed);
		}

		//transform.forward = this.GetComponent<Rigidbody2D>().velocity;
	}

	// Update is called once per frame
	void Update () {

	}

	/*
	void OnCollisionEnter2D(Collider2D collider)
	{
		//Destroy (this.gameObject);
	}
	*/

	public void IsEnemy(bool isEnemy)
	{
		this.isEnemy = isEnemy;
	}
	public void SetTarget(int city){this.targetCity = city;}
}
