using TMPro;
using UnityEngine;

public class PlayerWarning : MonoBehaviour
{
    [SerializeField] private TMP_Text _warningText;
    [SerializeField] private Animator _animator;

    public void Show(string warningText)
    {
        _warningText.text = warningText;
        _animator.Play(AnimatorPlayerWarningContoller.States.FadeIn);
    }
}