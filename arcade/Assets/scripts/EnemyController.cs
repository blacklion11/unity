using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int min = -10;
	public int max = 10;

	public GameObject missilePrefab;

	public int maxMissiles;
	public int maxPerWave;


	// Use this for initialization
	void Start () {
		spawnMissile();

		StartCoroutine("spawnWaves");
	}
	
	// Update is called once per frame
	void Update () {}

	public IEnumerator spawnWaves()
	{
		for(int i = 0; i < maxMissiles; i++)
		{
			spawnMissile();
			yield return new WaitForSeconds(1);
		}


	}


	void spawnMissile()
	{
		int spawnX = Random.Range(min, max);
		int spawnY = 9;

		Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0);

		GameObject missile = Instantiate(missilePrefab, spawnPoint, Quaternion.identity) as GameObject;

		// randomly select a city and store the position as the targetPos.
		int city = Random.Range(0, 5);
		missile.GetComponent<MissileController>().IsEnemy(true);
		missile.GetComponent<MissileController>().SetTarget(city);
	}

}
