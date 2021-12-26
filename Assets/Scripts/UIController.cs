using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text textTMP;
    [SerializeField] GameObject menuPanel;

    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public void PauseGame()
    {
        if (!GameManager.instance.isPaused)
        {
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
            GameManager.instance.isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            menuPanel.SetActive(false);
            GameManager.instance.isPaused = false;
        }
    }

    public void UpdateLevelText(int _level)
    {
        textTMP.text = "Level : " + _level;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }

    UIController() { }
}
