using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject water;
    public float speed;
    public float gracePeriod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gracePeriod -= Time.deltaTime;
        if(gracePeriod <= 0){
            if(water.transform.position.y < -1){
                water.transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
            }
        }
    }

 
}
