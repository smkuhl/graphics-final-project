using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player, platform;
    private Vector3 movement = Vector3.left / 10;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Update is called once per frame
    void FixedUpdate()
    {
        // platform movement
        if(platform.transform.localPosition.x > 183 || platform.transform.localPosition.x < 60)
            movement *= -1;
        platform.transform.position += movement;

        // player movement
        if (Mathf.Abs(player.transform.position.x - platform.transform.position.x) < 10
            && Mathf.Abs(player.transform.position.z - platform.transform.position.z) < 10
            && Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)) {
                player.transform.position += movement;
        }
    }
}
