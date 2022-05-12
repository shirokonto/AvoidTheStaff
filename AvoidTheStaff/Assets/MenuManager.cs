using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool _pauseMenuIsOpen;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        _pauseMenuIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandlePauseMenu();
    }

    private void HandlePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetMenuState();
            if (_pauseMenuIsOpen)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    
    public void ReturnToGame()
    {
        SetMenuState();
        Time.timeScale = 1;
    }

    private void SetMenuState()
    {
        _pauseMenuIsOpen = !_pauseMenuIsOpen;
        menu.SetActive(_pauseMenuIsOpen);
    }
}
