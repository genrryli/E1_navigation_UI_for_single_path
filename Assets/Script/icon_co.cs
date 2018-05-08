using UnityEngine;
using System.Collections;

public class icon_co : MonoBehaviour {

    public enum degree { rd45,rd90,rd135,rd180,ld45,ld90,ld135,ld180}
    //public degree degree_of_the_road;
    public degree next_degree;

    public GameObject panel;
    public GameObject[] icon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider Trigger)
    {

        if (Trigger.tag == "Player" )
        {
            panel.SetActive(false);
            int  i = (int )next_degree;
            icon[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider Trigger)
    {
        if (Trigger.tag == "Player")
        {
            panel.SetActive(true);
            int i = (int)next_degree;
            icon[i].SetActive(true);
        }
    }
}
