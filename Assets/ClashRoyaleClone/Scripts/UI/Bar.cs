using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Bar : MonoBehaviour
{
    private Image _filler;
    private Coroutine _changeBarAmountRoutine;
    private CharacterCharacteristic _targetValue;

    [Range(0.01f, 1)] [SerializeField] private float _smoothness = 1;

    private void Awake()
    {
        _filler = GetComponent<Image>();
        _targetValue = GetComponentInParent<CharacterCharacteristic>();
    }

    private void OnEnable()
    {
        _targetValue.AmountChangedEvent += OnAmountChanged;
    }

    private void OnDisable()
    {
        _targetValue.AmountChangedEvent -= OnAmountChanged;
    }

    private void OnAmountChanged(int currentAmount)
    {
        if (_changeBarAmountRoutine != null)
        {
            StopCoroutine(_changeBarAmountRoutine);
        }

        _changeBarAmountRoutine = StartCoroutine(ChangeBarAmountRoutine(_targetValue.NormalizedAmount));
    }

    private IEnumerator ChangeBarAmountRoutine(float normalizedAmount)
    {
        while (!Mathf.Approximately(_filler.fillAmount, normalizedAmount))
        {
            _filler.fillAmount = Mathf.MoveTowards(_filler.fillAmount, normalizedAmount, Time.deltaTime * _smoothness);
            yield return null;
        }
    }
}