using UnityEngine;

public class CurrencyItem : MonoBehaviour
{
    [SerializeField] private CurrencyAsset currencyAsset;
    [SerializeField] private float currencyAmount;

    public void Claim()
    {
        currencyAsset.EarnCurrency(currencyAmount);
        gameObject.SetActive(false);
    }
}
