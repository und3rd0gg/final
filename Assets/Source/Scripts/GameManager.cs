using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Health _playerTowerHealth;
    [SerializeField] private Health _enemyTowerHealth;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    
    public static GameManager Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _playerTowerHealth.AmountEnded += PlayerLose;
        _enemyTowerHealth.AmountEnded += PlayerWon;
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

    public void PauseGame(float delay)
    {
        StartCoroutine(DelayRoutine());

        IEnumerator DelayRoutine()
        {
            yield return new WaitForSeconds(delay);
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}