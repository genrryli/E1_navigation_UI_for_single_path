using UnityEngine;
using System.Collections;

public class road_check : MonoBehaviour {

    void OnTriggerEnter(Collider Trigger)
    {
        if (Trigger.tag == "final_check")
        {
            game_manager.gm.finished_loop ++;
        }
    }
}
