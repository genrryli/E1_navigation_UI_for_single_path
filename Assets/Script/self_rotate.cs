using UnityEngine;
using System.Collections;

public class self_rotate : MonoBehaviour {
    public float y_speed;
    public float x_speed;
    public float z_speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(x_speed,y_speed , z_speed));
	}
}
