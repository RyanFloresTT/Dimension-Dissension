using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("level1");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
