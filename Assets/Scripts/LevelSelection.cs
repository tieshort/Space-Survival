
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    private List<Button> levelButtons = new();
    [SerializeField] private Button levelButtonPrefab;
    [SerializeField] private RectTransform levelsGrid;

    void Start()
    {
        levelButtons.Clear();

        for (int i = 0; i < Levels.Instance.totalLevelsCount; i++)
        {
            Button levelButton = Instantiate(levelButtonPrefab, levelsGrid);
            int levelIndex = i;

            if (levelIndex > Levels.Instance.lastUnlockedLevel)
            {
                levelButton.interactable = false;
                continue;
            }

            levelButton.onClick.AddListener(() => {
                Levels.Instance.LoadLevel(levelIndex);
                Debug.Log("Загружаем уровень " + levelIndex);
                });
            levelButtons.Add(levelButton);
        }
    }
}
