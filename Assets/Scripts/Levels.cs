using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public static Levels Instance {  get; private set; }
    public Level menuLevel;
    public Level levelSelectionLevel;
    public Level shopLevel;

    public Level[] levelsList;

    public int lastPlayedLevel = 0;
    public int lastUnlockedLevel;
    public int totalLevelsCount;

    public UnityEvent OnLevelWon;
    public UnityEvent OnLevelLost;

    private void Awake()
    {
        Instance = this;
        totalLevelsCount = levelsList.Length;

        DontDestroyOnLoad(gameObject);

        OnLevelWon.AddListener(TryUnlockLevel);
    }

    public void LoadMenu()
    {
        menuLevel.Load();
    }

    public void LoadLastPlayedLevel()
    {
        int index = lastPlayedLevel;
        levelsList[index].Load();
    }

    public void LoadLevelSelection()
    {
        levelSelectionLevel.Load();
    }

    public void LoadLevel(int index)
    {
        if (index < 0 || index >= totalLevelsCount)
        {
            return;
        }

        lastPlayedLevel = index;
        LoadLastPlayedLevel();
    }

    public void LoadShop()
    {
        shopLevel.Load();
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }

    private void TryUnlockLevel()
    {
        lastUnlockedLevel = Mathf.Max(lastUnlockedLevel, lastPlayedLevel + 1);
    }
}

[Serializable]
public struct Level 
{
    public SceneAsset levelScene;

    public void Load()
    {
        SceneManager.LoadScene(levelScene.name);
    }
}
