using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private UIDocument mainMenuUIDocument;

    [SerializeField] private string startButtonName = "start-game__button";
    [SerializeField] private string selectLevelButtonName = "select-level__button";
    [SerializeField] private string shopLevelButtonName = "shop-level__button";
    [SerializeField] private string exitButtonName = "exit__button";

    [SerializeField] private MainMenu mainMenuController;

    private Button startButton;
    private Button selectLevelButton;
    private Button shopLevelButton;
    private Button exitButton;

    public void OnEnable()
    {
        if (!mainMenuUIDocument) mainMenuUIDocument = GetComponent<UIDocument>();
        if (!mainMenuController) mainMenuController = GetComponent<MainMenu>();

        startButton = mainMenuUIDocument.rootVisualElement.Q<Button>(startButtonName);
        selectLevelButton = mainMenuUIDocument.rootVisualElement.Q<Button>(selectLevelButtonName);
        shopLevelButton = mainMenuUIDocument.rootVisualElement.Q<Button>(shopLevelButtonName);
        exitButton = mainMenuUIDocument.rootVisualElement.Q<Button>(exitButtonName);


        startButton.clicked += StartButton_clicked;
        selectLevelButton.clicked += SelectLevelButton_clicked;
        shopLevelButton.clicked += ShopLevelButton_clicked;
        exitButton.clicked += ExitButton_clicked;
    }

    private void ShopLevelButton_clicked()
    {
        mainMenuController.LoadShopScene();
    }

    private void StartButton_clicked()
    {
        mainMenuController.LoadLastPlayedLevel();
    }

    private void SelectLevelButton_clicked()
    {
        mainMenuController.LoadLevelSelectionScene();
    }

    private void ExitButton_clicked()
    {
        mainMenuController.ExitGame();
    }

    public void OnDisable()
    {
        startButton.clicked -= StartButton_clicked;
        selectLevelButton.clicked -= SelectLevelButton_clicked;
        shopLevelButton.clicked -= ShopLevelButton_clicked;
        exitButton.clicked -= ExitButton_clicked;
    }
}
