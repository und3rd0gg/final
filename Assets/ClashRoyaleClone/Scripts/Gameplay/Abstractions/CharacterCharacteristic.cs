using System;
using UnityEngine;

public abstract class CharacterCharacteristic : MonoBehaviour
{
    [SerializeField] protected int _amount;

    [Header("Basic Values")] [SerializeField]
    protected int _minAmount = 0;

    [SerializeField] protected int _maxAmount = 100;
    
    public event Action<int> AmountChanged;

    public event Action AmountEnded;

    public int Amount
    {
        get => _amount;
        protected set
        {
            _amount = Mathf.Clamp(value, _minAmount, _maxAmount);
            AmountChanged?.Invoke(_amount);

            if (value <= _minAmount)
                AmountEnded?.Invoke();
        }
    }

    public float NormalizedAmount => Mathf.Abs((float) _amount / _maxAmount);

    protected void OnEnable()
    {
        AmountChanged?.Invoke(_amount);
    }
}