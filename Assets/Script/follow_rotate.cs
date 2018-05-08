using UnityEngine;
using System.Collections;

public class follow_rotate : MonoBehaviour {

    public GameObject rotate_target;

    private Vector3 offset;

    void Start()
    {

    }

    void LateUpdate()
    {
        transform.rotation = rotate_target.transform.rotation;
    }
}
