using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Emitter : MonoBehaviour
{
    public float interval = 10;
    public GameObject sphereGameObject; 
    private float timer = 0;
    
    // Colliders in the scene

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float deltaTime = Time.deltaTime;
        if(timer >= interval){
            Rigidbody rb = sphereGameObject.GetComponent<Rigidbody>();
            rb.mass = Random.Range(1, 5);
            GameObject duplicate = Instantiate(sphereGameObject, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
