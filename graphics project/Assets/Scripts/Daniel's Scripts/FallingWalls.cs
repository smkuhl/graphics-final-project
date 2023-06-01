using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWalls : MonoBehaviour
{
    public GameObject wall1, wall2, wall3, entranceTrigger;
    private float velocity;
    private float startTime = float.MaxValue;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > 4)
            wall1.GetComponent<Rigidbody>().useGravity = true;
        if (Time.time - startTime > 5)
            wall2.GetComponent<Rigidbody>().useGravity = true;
        if (Time.time - startTime > 6)
            wall3.GetComponent<Rigidbody>().useGravity = true;
    }

    public void setStartTime(float time) {
        startTime = time;
    }
}
