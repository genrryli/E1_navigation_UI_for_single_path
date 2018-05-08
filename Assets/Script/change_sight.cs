using UnityEngine;
using System.Collections;

public class change_sight : MonoBehaviour {

 
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void change(bool x)
    {
        if (x)
        {
            GameObject.Find("sihght_con").GetComponent<Animator>().SetBool("up", true);
        }
        if (!x)
        { 
            GameObject.Find("sihght_con").GetComponent<Animator>().SetBool("up", false);
        }
    }
}
