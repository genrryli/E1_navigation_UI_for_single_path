using UnityEngine;
using System.Collections;

public class block_adder : MonoBehaviour {

    public GameObject[] block_item;
    public GameObject player;
    public float set_add_time=3;


    private float timer;
    private int number;
	// Use this for initialization
	void Start () {
        
        number = block_item.Length;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= set_add_time) { add_block();timer = 0; }
        
	}

    void add_block()
    {
        int n = Random.Range(0, number);
        float x = Random.Range(-2f, 2f)+ player.transform.position.x;
        float z = Random.Range(20f, 50f)+ player.transform.position.z;
        Quaternion q = player.transform.rotation;
        Rigidbody new_block = Instantiate(block_item[n], new Vector3(x, player.transform.position.y+3, z),q) as Rigidbody;
    }
         
}
