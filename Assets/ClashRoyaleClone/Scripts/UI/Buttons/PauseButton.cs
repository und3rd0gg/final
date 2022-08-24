using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private MenuCanvas _menuCanvas;
    
    private Button _button;
    private Image _image;

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
        _menuCanvas.Activate();
        _image.enabled = false;
    }
}