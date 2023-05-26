using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swings : MonoBehaviour
{
    public GameObject swing;
    private Transform leftSwing;
    private Transform rightSwing;
    //private Quaternion originalAng;

    // Start is called before the first frame update
    void Start()
    {
        //originalAng = transform.rotation;
        leftSwing = swing.transform.Find("Left swing container");
        rightSwing = swing.transform.Find("Right swing container");
    }

    // Update is called once per frame
    void Update()
    {
        leftSwing.transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 200f, 90) - 45);
        rightSwing.transform.localEulerAngles = new Vector3(0, 0, 45 - Mathf.PingPong(Time.time * 200f, 90));
    }
}
