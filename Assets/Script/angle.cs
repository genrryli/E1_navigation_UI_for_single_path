using UnityEngine;
using System.Collections;

public class angle : MonoBehaviour {

    public GameObject boom;
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider Trigger)
    {

        if (Trigger.tag == "attack"|| Trigger.tag == "effect"||Trigger.tag=="block")
        {
            Destroy(Trigger.gameObject);
            Instantiate(boom, Trigger.transform.position, Trigger.transform.rotation);
        }
        if (timer >= 10)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
