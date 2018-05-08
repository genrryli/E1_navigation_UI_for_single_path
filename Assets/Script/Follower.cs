using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour
{

    public GameObject FollowObject;
    public int SelfMass = 3;
    public int SelfDrag = 2;
    public int FollowSpeed = 30;

    private Vector3 offset;
    private Vector3 newoffset;
    private Vector3 posi;
    private Rigidbody go;

    void Start()
    {
        offset = transform.position - FollowObject.transform.position;
        go = GetComponent<Rigidbody>();
        go.mass = SelfMass;
        go.drag = SelfDrag;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        posi = FollowObject.transform.position + offset;
        newoffset = transform.position - posi;
        if (newoffset != new Vector3(0, 0, 0))
            go.AddForce(-newoffset * FollowSpeed);
    }

}