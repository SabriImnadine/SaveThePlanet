using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/CollectQuest")]
public class QuestData : ScriptableObject
{
    public string questName;
    public int requiredAmount = 5;
    public int currentAmount = 0;

    public bool isStarted = false;
    public bool isCompleted = false;

    public void ResetProgress()
    {
        currentAmount = 0;
        isStarted = false;
        isCompleted = false;
    }
}
