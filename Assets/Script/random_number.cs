using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class random_number : MonoBehaviour {

    public Text[] squre; 
    public Text[] cylinder;
    public Text[] sphere;
    public int min_number;
    public int max_number;

    private int interval;
	// Use this for initialization
	void Start () {
        interval=(max_number-min_number)/3;
        int _first = Random.Range(min_number, min_number + interval);
        int _second=Random.Range(min_number+interval,min_number+interval*2);
        int _third=Random.Range(min_number+interval*2,max_number);
        for(int i=0;i<=squre.Length-1;i++){
            squre[i].text=""+_first;
            cylinder[i].text=""+_second;
            sphere[i].text=""+_third;
        }
    }
}
