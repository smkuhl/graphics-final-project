using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private float fixedDeltaTime;

    void awake() {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1.0f;

        if (Input.GetMouseButton(1)) {
            Time.timeScale = 0.5f;
        }
    }
}
