using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    public float F;
    public float stop_s;
    public GameObject boom;
    public AudioClip shound;

    private float timer=0;
	// Use this for initialization
	void Start () {
        AudioSource.PlayClipAtPoint(shound, transform.position, 1000);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 1.5)
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);            
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("com"))
        {
            collision.gameObject.GetComponent<NavMeshAgent>().speed =stop_s;
            Rigidbody ri = collision.gameObject.GetComponent<Rigidbody>();
            ri.AddForce(transform.forward * -F);
            ri.AddForce(transform.up * F);

            GameObject InstanceItem = Instantiate(boom, transform.position, transform.rotation) as GameObject;

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == ("block"))
        {
            GameObject InstanceItem = Instantiate(boom, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
    }
}
