using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _uiWidgetPauseMenu;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        _uiWidgetPauseMenu.SetActive(true);
        _animator.Play(AnimatorUiWidgetMenuCanvasController.States.FadeIn);
        var activationTime = _animator.GetCurrentAnimatorStateInfo(0).length;
        GameManager.Instance.PauseGame(activationTime);
    }
}
