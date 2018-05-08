using UnityEngine;
using System.Collections;

public class hover : MonoBehaviour {

    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    private float proportionalHeight;
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            gameObject.transform.Translate(Vector3.up * proportionalHeight * hoverForce);
        }
    }
}
