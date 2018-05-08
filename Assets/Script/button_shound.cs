using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;

public class button_shound : MonoBehaviour
{

    public AudioClip select;
    public AudioClip hover;
    public AudioClip slide;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void button_hover_audio()
    {
        GetComponent<AudioSource>().PlayOneShot(hover);
    }

    public void button_select_audio()
    {
        GetComponent<AudioSource>().PlayOneShot(select);
    }

    public void button_slide_audio()
    {
        GetComponent<AudioSource>().PlayOneShot(slide);
    }
}