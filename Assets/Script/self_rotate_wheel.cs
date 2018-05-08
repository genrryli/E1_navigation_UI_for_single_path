using UnityEngine;
using System.Collections;

public class self_rotate_wheel : MonoBehaviour {
    
    public Transform r_center;
    public bike_con bc;
    public float speed_scale;

    private float speed;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        speed = bc.real_speed_;
        transform.RotateAround(r_center.position , r_center.right, speed * Time.deltaTime*speed_scale);	
	}
}
