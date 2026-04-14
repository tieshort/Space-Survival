using UnityEngine;
using UnityEngine.Events;

public abstract class WinConditionChecker : MonoBehaviour
{
    [SerializeField] private float checkConditionStep = 0.2f;
    private float checkConditionTimer = 0;

    public UnityEvent OnWinConditionReached;

    public abstract bool IsConditionReached();

    private void Update()
    {
        if (checkConditionTimer > 0)
        {
            checkConditionTimer -= Time.deltaTime;
            return;
        }

        checkConditionTimer = checkConditionStep;
        if (IsConditionReached())
        {
            Win();
        }
    }

    private void Win()
    {
        Levels.Instance.OnLevelWon.Invoke();
        OnWinConditionReached.Invoke();

        //Levels.Instance.LoadLevelSelection();
    }
}
