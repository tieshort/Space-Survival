using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyAsset", menuName = "Scriptable Objects/Currency/CurrencyAsset")]
public class CurrencyAsset : ScriptableObject
{
    [SerializeField] private float currencyAmount;
    public float CurrencyAmount { get => currencyAmount; }

    [SerializeField] private float tmpCurrencyVault;
    public float TmpCurrencyAmount { get => tmpCurrencyVault; }

    public bool TrySpendCurrency(float value)
    {
        if (value > CurrencyAmount) return false;

        currencyAmount -= value;
        return true;
    }

    public void EarnCurrency(float value, bool tmp = true)
    {
        if (tmp)
        {
            tmpCurrencyVault += value;
            return;
        }
        currencyAmount += value;
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
