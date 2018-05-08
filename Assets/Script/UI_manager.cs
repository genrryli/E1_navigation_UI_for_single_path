using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void play_E1()
    {
        SceneManager.LoadScene("E1");
		GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<motion_data> ().close_port ();
    }

    public void play_E1_warmup()
    {
        SceneManager.LoadScene("E1_warmup");
    }

    public void play_E1_outset()
    {
        SceneManager.LoadScene("E1_outset");
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<motion_data>().close_port();
    }

}
