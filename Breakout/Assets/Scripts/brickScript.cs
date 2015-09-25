using UnityEngine;
using System.Collections;

public class brickScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		StartCoroutine(destroyBrick());

	}



	IEnumerator destroyBrick(){
		yield return new WaitForSeconds(.01f);
		Destroy (this.gameObject);


	}
}
