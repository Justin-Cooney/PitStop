using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private bool _isCreditsShowing = false;
    private bool _isControlsShowing = false;

    public void OnPlay()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    public void OnZombies()
    {
        SceneManager.LoadScene("Swarm", LoadSceneMode.Single);
    }

    public void OnControls()
    {
        if (!_isControlsShowing)
        {
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadScene("Controls");
        }

        _isControlsShowing = !_isControlsShowing;
    }

    public void OnCredits()
    {
        if (!_isCreditsShowing)
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadScene("Credits");
        }

        _isCreditsShowing = !_isCreditsShowing;
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
