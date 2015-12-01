using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {


	public int health;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void Hit(int damage)
	{
		health -= damage;
		//Debug.Log (health);
		if (health <= 0) 
		{
			Die();
		}
	}

	void Die()
	{

		if (this.gameObject.tag.Contains ("Player")) {
			//GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			//camera.transform.SetParent(null);
			//GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().SpawnPlayer();

			Application.LoadLevel(Application.loadedLevel);
		}
		else
		{

		}
		Destroy (this.gameObject);
	}
}
