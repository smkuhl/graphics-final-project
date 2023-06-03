using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject fallingWalls, bridge;
    private Vector3 velocity;

    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -50){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.unscaledDeltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.unscaledDeltaTime;
        // delta y = 1/2 g t^2
        controller.Move(velocity * Time.unscaledDeltaTime);

    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Collectible")) {
            collision.gameObject.SetActive(false);
            bridge.GetComponent<Bridge>().incrementCount();            
        }
        
        if (collision.gameObject.CompareTag("Swing"))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("WallsEntrance")) {
           fallingWalls.GetComponent<FallingWalls>().setStartTime(Time.time);
           collision.gameObject.SetActive(false);
        }
    }
}