using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    private void Awake()
    {
        LockCursor();
    }

    public void troca(string tp)
    {
        SceneManager.LoadScene(tp);
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        UnLockCursor();
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        isPaused = true;
    }

    void ResumeGame()
    {
        LockCursor();
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("ESC"))
        {
            TogglePause();
        }


        if (Input.GetButtonDown("E"))
        {
            UnLockCursor();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
