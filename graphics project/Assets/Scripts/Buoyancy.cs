using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Buoyancy : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underWaterAngularDrage= 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public GameObject water;
    Rigidbody m_Rigidbody;
    bool underwater;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float waterHeight = water.transform.position.y;
        float diff = transform.position.y - waterHeight;
        if(diff < 0){
            m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff), transform.position, ForceMode.Force);
            if(!underwater){
                underwater = true;
                SwitchState(true);
            } 
        }
        else if(underwater){
                underwater = false;
                SwitchState(false);
        }
    }

    void SwitchState(bool isUnderwater){
        if(isUnderwater){
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrage;

        } else{
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
}
