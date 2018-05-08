using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour
{
    public float distroy_time = 1.5f; 

    void Start()
    {
        Destroy(gameObject, distroy_time);
    }
}