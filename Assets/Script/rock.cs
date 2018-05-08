using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {

    public GameObject rock_break;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        //float ff = collision.gameObject.GetComponent<Rigidbody>().;
        //if (collision.rigidbody.constantForce >= 10;)
        Instantiate(rock_break, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
