using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonTarget;

    private bool extending = true;

    // Start is called before the first frame update
    void Start()
    {
        cannonTarget = GameObject.FindWithTag("Cannon");
    }

    // Update is called once per frame
    void Update()
    {
        if(extending){
            cannonTarget.transform.localScale += new Vector3(0.000f, 0.05f * Time.timeScale, 0.000f);
        } else {
            cannonTarget.transform.localScale += new Vector3(0.000f, -0.05f * Time.timeScale, 0.000f);
        }

        if(cannonTarget.transform.localScale.y >= 42){
            extending = false;
        }
        if(cannonTarget.transform.localScale.y <= 1){
            extending = true;
        }
    }
}
