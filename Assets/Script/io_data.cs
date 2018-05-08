using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class io_data : MonoBehaviour {

    public Toggle io;
    public InputField com;
	// Use this for initialization
	void Start () {
        com.text="COM4";
        io.isOn=true;
	}
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        if (io.isOn) { i = 1; }else if (!io.isOn) { i = 0; }
        PlayerPrefs.SetInt("io", i);
        PlayerPrefs.SetString("com", com.text);	
	}
}
