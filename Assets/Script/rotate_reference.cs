using UnityEngine;
using System.Collections;

public class rotate_reference : MonoBehaviour {
    public Transform forward;
    public Transform backward;
    public Transform left;
    public Transform right;
    public Transform father;

    private Vector3 x_axis;
    public Vector3 z_axis;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        x_axis =backward.position - forward.position;
        z_axis = right.position- left.position;
        float angle_x = Mathf.Atan(x_axis.y / x_axis.z)*180/Mathf.PI;
        float angle_z = Mathf.Atan(z_axis.y / z_axis.x) * 180 / Mathf.PI;
        float angle_y = father.transform.localEulerAngles.y;
        transform.eulerAngles=(new Vector3 (-angle_x,angle_y,angle_z));
	}
}
