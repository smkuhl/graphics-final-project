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
        // reset level if fallen off or pressing r
        if (transform.position.y < -50 || Input.GetKeyDown("r"))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        //  jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.unscaledDeltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.unscaledDeltaTime;
        controller.Move(velocity * Time.unscaledDeltaTime);

    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Collectible")) {
            collision.gameObject.SetActive(false);
            bridge.GetComponent<Bridge>().incrementCount();            
        }

        if (collision.gameObject.CompareTag("WallsEntrance")) {
           fallingWalls.GetComponent<FallingWalls>().setStartTime(Time.time);
           collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Door")) {
            if (SceneManager.GetActiveScene().buildIndex == 5) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("Win Screen");
            } else {
                int nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(nextSceneLoad);

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
}
