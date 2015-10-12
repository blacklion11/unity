using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


    private GameObject player;
    public float zoom;
    private Camera camera;

	// Use this for initialization
	void Start () {
        this.player = GameObject.FindWithTag("Player");
        camera = GetComponent<Camera>();
	}

    public void assignPlayer(GameObject player)
    {
        this.player = player;
    }

	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            camera.orthographicSize = zoom;
        }
	}
}
