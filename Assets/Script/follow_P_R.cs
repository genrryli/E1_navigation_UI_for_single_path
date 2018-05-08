using UnityEngine;
using System.Collections;

public class follow_P_R : MonoBehaviour {

    public bool get_rotation;
    public bool get_position;
    public bool get_ground_position;
    public GameObject rotate_target;
    public GameObject translate_target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (get_rotation) { transform.rotation = rotate_target.transform.rotation; }
        if (get_position) { transform.position = translate_target.transform.position; }
        if (get_ground_position)
        {
            Ray x = new Ray(translate_target.transform.position, -Vector3.up);
            RaycastHit hit;
            if (Physics.Raycast(x, out hit))
            {
                transform.position = hit.point;
            }

        }
	}
}
