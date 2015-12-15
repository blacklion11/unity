using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public BoardCreator BC;
	private static int level = 1;
	// Use this for initialization
	void Start () {
		BC.CreateBoard();
		
		Debug.Log("Level " + level + " loaded");
	}
	
	public int getLevel(){
		return level;
	}
	
	public void nextLevel(){
		level++;
	}
	public void restart(){
		level = 1;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
