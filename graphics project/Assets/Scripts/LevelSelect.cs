using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReturntoStart()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
