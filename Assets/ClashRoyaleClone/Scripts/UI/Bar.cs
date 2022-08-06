using System.Collections;
using ClashRoyaleClone.Scripts.Game.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace ClashRoyaleClone.Scripts.UI
{
    [RequireComponent(typeof(Image))]
    public class Bar : MonoBehaviour
    {
        private Image _filler;
        private Coroutine _changeBarAmountRoutine;
    
        [SerializeField] private CharacterCharacteristic _targetValue;
        [Range(0.01f, 1)]
        [SerializeField] private float _smoothness;

        private void Awake()
        {
            _filler = GetComponent<Image>();
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
}
