using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public BoardCreator BC;
	private static int level = 0;
	// Use this for initialization
	void Start () {
		level++;
		if(level % 5 == 0){
			BC.CreateBoard();
		}else{
			BC.CreateBoard();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
