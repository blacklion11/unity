using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject circle;
    private float radius;

    private Vector3 world_pos;
	// Use this for initialization
	void Start () {
        radius = circle.transform.localScale.x / 2;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 screen_pos = Input.mousePosition;
            world_pos = Camera.main.ScreenToWorldPoint(screen_pos);
            world_pos.z = 0;
            Debug.Log(world_pos);
        }
	}

    IEnumerator moveto()
    {
        Vector3 source = transform.position;

        Vector3 destination = GetComponent<SphereCollider>().ClosestPointOnBounds(world_pos);
        Debug.Log(destination);
        return null;
    }
    
}
