using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void OnClickPlay()
    {
        // Load the scene for the first level
        SceneManager.LoadScene("level1");
    }
    public void OnClickExit()
    {
        // Load the scene for the first level
        Application.Quit();
    }
}
