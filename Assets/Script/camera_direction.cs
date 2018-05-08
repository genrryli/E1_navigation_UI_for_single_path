using UnityEngine;
using System.Collections;

public class camera_direction : MonoBehaviour {

    public GameObject start_location;
    public GameObject late_location;
    public Transform directe_con;

    private Vector3 directe;
    private Vector3 directe2;

    void Start()
    {
    }

    void Update()
    {
        if (directe_con.localEulerAngles.x <=360 && directe_con.localEulerAngles.x >= 270)
        {
            late_location.SetActive(true);
            start_location.SetActive(false);
        }
        else
        {
            start_location.SetActive(true);
            late_location.SetActive(false);
        }
                
    }

}
