using UnityEngine;
using System.Collections;

public class coli_reader : MonoBehaviour {
    
    private float speed_scale;
    public AudioClip hit;

    void Start()
    {
        speed_scale=gameObject.GetComponent<bike_con>().riding_scale;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "wall")
        {
            GameObject.Find("managers").GetComponent<data_manager>().coli_times_data(collision.transform.tag);
            Vector3 contact = collision.transform.position;
            GameObject.Find("managers").GetComponent<data_manager>().coli_posi_data(contact);   
        }

        if (collision.transform.tag == "block")
        {
            GameObject.Find("managers").GetComponent<data_manager>().coli_times_data(collision.transform.tag);
            Vector3 contact = collision.transform.position;
            GameObject.Find("managers").GetComponent<data_manager>().block_coli_posi_data(contact);
        }
    }

    void OnTriggerStay(Collider co)
    {
        if (co.transform.tag == "block" || co.transform.tag == "wall")
        {
            AudioSource.PlayClipAtPoint(hit, transform.position, 0.2f);
        }
    }
    }
