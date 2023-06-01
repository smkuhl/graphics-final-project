using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject redLight, ylwLight, grnLight, player;

    // 0 - red, 1 - yellow, 2 - green
    private GameObject[] lights;
    private int activeLight;
    
    private float lastSwap;
    private bool inArea;
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lights = new GameObject[] {redLight, grnLight, ylwLight};
        activeLight = 0;
        lastSwap = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // handles which light is on
        switch(activeLight) {
            case 0:
                if (Time.time - lastSwap > (Random.Range(3, 10))) nextLight();
                break;
            case 1:
                if (Time.time - lastSwap > (Random.Range(3, 10))) nextLight();
                break;
            case 2:
                if (Time.time - lastSwap > (Random.Range(3, 10))) nextLight();
                break;
        }

        // handles reset if moving while red light is on
        lastPos = player.transform.position;
        inArea = player.transform.position.z < -50;
        if (inArea && activeLight == 0) {
            if (!player.transform.position.Equals(lastPos)) {
                SceneManager.LoadScene("Daniel's Scene", LoadSceneMode.Single);
            }
        }
    }

    void nextLight() {
        lights[activeLight].GetComponent<Light>().intensity = 0;
        activeLight = (activeLight + 1) % lights.Length;
        lights[activeLight].GetComponent<Light>().intensity = 50;
        lastSwap = Time.time;
    }
}
