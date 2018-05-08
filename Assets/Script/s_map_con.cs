using UnityEngine;
using System.Collections;

public class s_map_con : MonoBehaviour {

	public GameObject terrain;
	public GameObject envionment;
	public GameObject block;
	public GameObject fance;
	public GameObject road;
	public GameObject s_map;

	// Use this for initialization
	void Start () {
		string zero_test=PlayerPrefs.GetString("_count");
		if(zero_test=="预测试"){
			terrain.SetActive(false);
			envionment.SetActive(false);
			block.SetActive(false);
			fance.SetActive(false);
			road.SetActive(false);
			s_map.SetActive(true);}
		else
			{
			terrain.SetActive(true);
			envionment.SetActive(true);
			block.SetActive(true);
			fance.SetActive(true);
			road.SetActive(true);
			s_map.SetActive(false);	
			}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
