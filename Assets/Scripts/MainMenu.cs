using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadLastPlayedLevel()
    {
        Levels.Instance.LoadLastPlayedLevel();
    }

    public void LoadLevelSelectionScene()
    {
        Levels.Instance.LoadLevelSelection();
    }

    public void ExitGame()
    {
        Levels.Instance.QuitGame();
    }
}
