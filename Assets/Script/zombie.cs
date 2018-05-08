using UnityEngine;
using System.Collections;

public class zombie : MonoBehaviour {

    public GameObject target;
    public float trace_speed=10;

    private Animator ani;
    private float timer;
	// Use this for initialization
	void Start () {
        ani = gameObject.GetComponent<Animator>();
        ani.SetTrigger("surface");
        if (target == null) { target = GameObject.FindGameObjectWithTag("Player"); }
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        transform.LookAt(target.transform);
        if (timer >= 2) { trace();}
	}

    void trace()
    {   
        float dis = Vector3.Distance(transform.position, target.transform.position);
        if (dis >= 1) { transform.Translate(0, 0, trace_speed * Time.deltaTime); ani.SetBool("trace", true); }
        else { ani.SetBool("trace", false); }
    }

    void attack()
    {
        ani.SetTrigger("attack");
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player") { attack(); }
        else { ani.ResetTrigger("attack"); ani.SetBool("trace", true); }
    }
}
