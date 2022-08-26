using TMPro;
using UnityEngine;

public class MoneyBalancePresenter : MonoBehaviour
{
    [SerializeField] MoneyBalance _moneyBalance;
    [SerializeField] private TMP_Text _balanceText;

    private void OnEnable()
    {
        _moneyBalance.AmountChanged += UpdateUiBalance;
    }

    private void OnDisable()
    {
        _moneyBalance.AmountChanged -= UpdateUiBalance;
    }

    private void UpdateUiBalance(int newBalance)
    {
        _balanceText.text = newBalance.ToString();
    }
}
