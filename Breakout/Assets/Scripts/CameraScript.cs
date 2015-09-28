using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public AudioClip bounce, brick;

	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void sound(int id)
    {
        if (id == 1)
        {
            this.GetComponent<AudioSource>().PlayOneShot(bounce);
        }
        else
        {
            this.GetComponent<AudioSource>().PlayOneShot(brick);
        }
    }
}
