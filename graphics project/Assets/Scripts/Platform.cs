using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject moveTarget;

    private bool rising = true;

    // Start is called before the first frame update
    void Start()
    {
        moveTarget = GameObject.FindWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        if(rising){
            moveTarget.transform.localScale += new Vector3(0.000f, 0.01f * Time.timeScale, 0.000f);
        } else {
            moveTarget.transform.localScale += new Vector3(0.000f, -0.01f * Time.timeScale, 0.000f);
        }

        if(moveTarget.transform.localScale.y >= 43){
            rising = false;
        }
        if(moveTarget.transform.localScale.y <= 1){
            rising = true;
        }
    }
}
