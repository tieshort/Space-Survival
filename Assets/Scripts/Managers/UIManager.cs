using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text remainingEnemiesLabel;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private TMP_Text currencyTotalAmountLabel;
    [SerializeField] private TMP_Text currencyTmpAmountLabel;
    [SerializeField] private CurrencyAsset currencyAsset;

    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Levels.Instance.OnLevelWon.AddListener(ShowWinPanel);
        Levels.Instance.OnLevelLost.AddListener(ShowLosePanel);
    }

    private void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    private void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

    private void LateUpdate()
    {
        remainingEnemiesLabel.text = spawner.RemainingEnemies.ToString();
        currencyTotalAmountLabel.text = currencyAsset.CurrencyAmount.ToString();
        currencyTmpAmountLabel.text = $"({currencyAsset.TmpCurrencyAmount})";
    }

    public void QuitButton_OnClick()
    {
        Levels.Instance.QuitGame();
    }

    public void RestartButton_OnClick()
    {
        Levels.Instance.LoadLastPlayedLevel();
    }

    public void ToMenuButton_OnClick()
    {
        Levels.Instance.LoadMenu();
    }
}
