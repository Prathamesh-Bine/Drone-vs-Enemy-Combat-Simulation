using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject crosshair;

    private InputAction pauseAction;
    bool isPaused = false;

    void Awake()
    {
        // Define a new action bound directly to the Escape key
        pauseAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/escape");
        
        // Tell the action what to do when pressed
        pauseAction.performed += ctx => 
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        };
    }

    void OnEnable()
    {
        // Actions must be enabled to listen for input
        pauseAction.Enable();
    }

    void OnDisable()
    {
        pauseAction.Disable();
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        
        if (crosshair != null) crosshair.SetActive(false);
        
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        
        if (crosshair != null) crosshair.SetActive(true);
        
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}