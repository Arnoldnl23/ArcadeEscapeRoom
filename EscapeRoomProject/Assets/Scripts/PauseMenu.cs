using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    private bool activeUI = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayWristUI();
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            DisplayWristUI();
        }
    }

    public void DisplayWristUI()
    {
        if (activeUI)
        {
            pauseUI.SetActive(false);
            activeUI = false;
            Time.timeScale = 1;
        }
        else
        {
            pauseUI.SetActive(true);
            activeUI = true;
            Time.timeScale = 0;
        }
    }

    public void resumeGame()
    {
        DisplayWristUI();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
