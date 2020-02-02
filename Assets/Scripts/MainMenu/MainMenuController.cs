using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private bool _controls = false;

    public void OnPlay()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    public void OnControls()
    {
        if (!_controls)
        {
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadScene("Controls");
        }

        _controls = !_controls;
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
