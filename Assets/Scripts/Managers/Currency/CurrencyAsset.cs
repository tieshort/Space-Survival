using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyAsset", menuName = "Scriptable Objects/Currency/CurrencyAsset")]
public class CurrencyAsset : ScriptableObject
{
    public float CurrencyAmount;

    public bool TrySpendCurrency(float value)
    {
        if (value > CurrencyAmount) return false;

        CurrencyAmount -= value;
        return true;
    }

    public void EarnCurrency(float value)
    {
        CurrencyAmount += value;
    }
}
