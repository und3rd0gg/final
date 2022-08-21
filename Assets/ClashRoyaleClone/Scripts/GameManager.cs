using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Health _playerTowerHealth;
    [SerializeField] private Health _enemyTowerHealth;

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    public static GameManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _playerTowerHealth.AmountEndedEvent += PlayerLose;
        _enemyTowerHealth.AmountEndedEvent += PlayerWon;
    }

    private void PlayerWon()
    {
        PauseGame();
        _winScreen.SetActive(true);
    }

    private void PlayerLose()
    {
        PauseGame();
        _loseScreen.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}