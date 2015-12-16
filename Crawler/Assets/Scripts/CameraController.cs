using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {


    private GameObject player;
    public float zoom;
    private Camera camera;
	public Text text;
	public GameObject heart;

	// Use this for initialization
	void Start () {
		while(player==null){
			this.player = GameObject.FindWithTag("Player");
			Debug.Log("looking for player");
		}
        camera = GetComponent<Camera>();
	}

    public void assignPlayer(GameObject player)
    {
        this.player = player;
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Cancel")){
			Application.LoadLevel("title");
		}
        if (player != null)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            camera.orthographicSize = zoom;
			text.transform.localPosition = new Vector3(Screen.width * .45f,Screen.height * .45f,0);
			heart.transform.position = new Vector3(text.transform.position.x + 0.3f, text.transform.position.y+0.4f);
        }
		text.text = player.GetComponent<PlayerController>().curBullets + "/" + player.GetComponent<PlayerController>().getMaxBullets()+ "   " + player.GetComponent<PlayerController>().health+ "";
	}
}
