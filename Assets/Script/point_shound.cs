using UnityEngine;
using System.Collections;

public class point_shound : MonoBehaviour {

    public AudioClip boom_voice;
	// Use this for initialization
	void Start () {
        AudioSource.PlayClipAtPoint(boom_voice, transform.position, 1);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
