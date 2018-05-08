using UnityEngine;
using System.Collections;

public class add_down_force : MonoBehaviour {

    public float f;
    public float world_f;
    public float rf;

    private Rigidbody ri;
    private float groundedRaycastDistance = 2f;          //在判定玩家是否在地面上时，向地面发射射线的射线长度
    private bool isGrounded;                        //玩家是否在地面上

    // Use this for initialization
    void Start () {
        ri = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        //从玩家的位置垂直向下发出长度为groundedRaycastDistance的射线，返回值表示玩家是否该射线是否碰撞到物体，该句代码用于检测玩家是否在地面上
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundedRaycastDistance);

    }

    // Update is called once per frame
    void Update()
    {
        ri.AddForce(-transform.up * f);
        if (!isGrounded) { ri.AddForce(-Vector3.up * world_f * 2); }
        ri.AddForce(-Vector3.up * world_f);


        if (transform.localEulerAngles.x > 1 && transform.localEulerAngles.x < 90) { ri.AddTorque(-transform.right * rf);}
        else if (transform.localEulerAngles.x > 270 && transform.localEulerAngles.x < 359) { ri.AddTorque(transform.right * rf); }
        //if (transform.localEulerAngles.y > 1 && transform.localEulerAngles.y < 180) { ri.AddTorque(-transform.up * rf); }
        //else if (transform.localEulerAngles.y > 180 && transform.localEulerAngles.y < 359) { ri.AddTorque(transform.up * rf); }
        if (transform.localEulerAngles.z > 1 && transform.localEulerAngles.z < 90) { ri.AddTorque(-transform.forward * rf); }
        else if (transform.localEulerAngles.z > 270 && transform.localEulerAngles.z < 359) { ri.AddTorque(transform.forward * rf); }
    }
}
