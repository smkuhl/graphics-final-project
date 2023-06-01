using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour
{
    public GameObject shrinkTarget;

    private bool shrinkBool = false;
    private bool growBool = false;
    // Start is called before the first frame update
    void Start()
    {
        shrinkTarget = GameObject.FindWithTag("ShrinkTarget");
    }
/*
    public void pressShrink(){
        if(shrinkBool){
            shrinkBool = false;
        } else {
            shrinkBool = true;
        }
    }

    public void pressGrow(){
        if(growBool){
            growBool = false;
        } else {
            growBool = true;
        }
    } */

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKey(KeyCode.Z)){
            shrinkTarget.transform.localScale += new Vector3(-0.0005f, -0.0005f, -0.0005f);
        }

        if (Input.GetKey(KeyCode.X)){
            shrinkTarget.transform.localScale += new Vector3(0.0005f, 0.0005f, 0.0005f);
        }

        shrinkTarget.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);


    }
}
