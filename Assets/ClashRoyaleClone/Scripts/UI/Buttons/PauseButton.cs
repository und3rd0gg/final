using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private float _gameStopDelay = 1f;

    private Button _button;
    private Image _image;
    private Coroutine _gameStopRoutine;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StopGame);
    }

    private void StopGame()
    {
        _image.enabled = false;

        if (_gameStopRoutine != null)
            return;

        _gameStopRoutine = StartCoroutine(GameStopRoutine(_gameStopDelay));
    }

    private IEnumerator GameStopRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0;
    }
}