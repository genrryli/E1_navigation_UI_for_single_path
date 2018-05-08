using UnityEngine;
using System.Collections;

public class stay_position : MonoBehaviour {

    public GameObject father;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = father.transform.position;
	}
}
