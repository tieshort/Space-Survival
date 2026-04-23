using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyAsset", menuName = "Scriptable Objects/Currency/CurrencyAsset")]
public class CurrencyAsset : ScriptableObject
{
    [SerializeField] private float currencyAmount;
    public float CurrencyAmount { get => currencyAmount; private set => currencyAmount = value; }

    [SerializeField] private float tmpCurrencyVault;

    public bool TrySpendCurrency(float value)
    {
        if (value > CurrencyAmount) return false;

        CurrencyAmount -= value;
        return true;
    }

    public void EarnCurrency(float value, bool tmp = true)
    {
        if (tmp)
        {
            tmpCurrencyVault += value;
            return;
        }
        CurrencyAmount += value;
    }

    public void ClaimTmpVault()
    {
        EarnCurrency(tmpCurrencyVault, tmp: false);
        ResetTmpVault();
    }

    public void ResetTmpVault()
    {
        tmpCurrencyVault = 0;
    }
}
