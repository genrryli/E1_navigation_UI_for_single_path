using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class option_button : MonoBehaviour {

    public void transform_data()
    {
        int data;
        data = int.Parse(gameObject.transform.FindChild("Text").GetComponent<Text>().text);
        GameObject.Find("managers").GetComponent<data_manager>().quest(data);
    }

    public void transform_data(bool yes)
    {
        GameObject.Find("managers").GetComponent<data_manager>().quest(yes);
    }
}
