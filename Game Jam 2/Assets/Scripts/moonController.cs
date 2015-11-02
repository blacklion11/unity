using UnityEngine;
using System.Collections;

public class moonController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x < -12){
			Destroy(this.gameObject);
		}
	}
}
