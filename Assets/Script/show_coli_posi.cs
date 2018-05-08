using UnityEngine;
using System.Collections;

public class show_coli_posi : MonoBehaviour {

    public GameObject point;
    public GameObject block_point;
    private GameObject new_point;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void show_p(Vector3 posi,string obj)
    {
        if (obj == "wall") { new_point = Instantiate(point, posi, new Quaternion(0, 0, 0, 0)) as GameObject; }
        if (obj == "block") { new_point = Instantiate(block_point, posi, new Quaternion(0, 0, 0, 0)) as GameObject; }
    }
}
