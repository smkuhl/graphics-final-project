using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oscillator : MonoBehaviour
{
    private Vector3 originalPos;

    public float t = 800f; // speed
    public float l = 20f; // length from 0 to endpoint.
    public float posX = -10f; // Offset

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(-25 + Mathf.PingPong(10f * Time.time, 50), originalPos.y, originalPos.z);
        transform.position = pos;

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Jackie Scene");
        }
    }

}
