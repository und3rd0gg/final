using System;
using System.Collections;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [Min(1)] [SerializeField] private float _increaseBalanceDelay = 1;
    [Min(1)] [SerializeField] private int _increaseBalanceValue = 2;
    [field: SerializeField] public int Amount { get; private set; }

    public event Action<int> AmountChanged;

    private void Start()
    {
        AmountChanged?.Invoke(Amount);
        StartCoroutine(BalanceIncreaseRoutine());
    }

    public bool TrySpend(int amount)
    {
        if ((Amount - amount) >= 0)
        {
            Amount -= Mathf.Abs(amount);
            AmountChanged?.Invoke(Amount);
            return true;
        }

        return false;
    }

    public void Add(int amount)
    {
        Amount += Math.Abs(amount);
        AmountChanged?.Invoke(Amount);
    }

    private IEnumerator BalanceIncreaseRoutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_increaseBalanceDelay);
            Amount += _increaseBalanceValue;
            AmountChanged?.Invoke(Amount);
        }
    }
}
