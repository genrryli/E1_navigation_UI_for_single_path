using UnityEngine;
using System.Collections;

public class set_false : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void button_destroy(bool x)
    {
        gameObject.SetActive(x);
    }
}
