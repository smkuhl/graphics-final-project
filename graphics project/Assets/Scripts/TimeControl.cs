using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeControl : MonoBehaviour
{
    public TMP_Text timeText;
    public AudioSource audio;
    private float fixedDeltaTime;
    private float pitchVal;

    void awake() {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time: " + Time.timeScale + "x";
        if (Input.GetKeyDown("q")) {
            Time.timeScale -= 0.25f;
            audio.pitch -= 0.05f;
        } else if (Input.GetKeyDown("e")){
            Time.timeScale += 0.25f;
            audio.pitch += 0.05f;
        }
    }
}
