using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public int speed;
    // uppper/lower bounds to "bounce" off
    private float upper, lower;
    private Vector3 v;

    void Start() {
        v = new Vector3(0, speed, 0);
        upper = transform.position.y + 4;
        lower = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lower) {
            transform.position.Set(transform.position.x, lower, transform.position.z);
            v.Set(v.x, Mathf.Abs(v.y), v.z);
        } else if (transform.position.y > upper) {
            transform.position.Set(transform.position.x, upper, transform.position.z);
            v.Set(v.x, -Mathf.Abs(v.y), v.z);
        }

        transform.position = transform.position + v * Time.deltaTime;
    }
}
