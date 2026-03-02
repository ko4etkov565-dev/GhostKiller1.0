using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;
    public int killsPerLevel = 25;
    public int difficultyLevel = 0;
    public int extraEnemiesPerLevel = 1;
    public float speedIncreasePerLevel = 0.5f;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else 
            Destroy(gameObject);

    }

    public void CheckDifficultyLevel(int totalKills)
    {
        int newLevel = totalKills / killsPerLevel;
        if(newLevel > difficultyLevel)
        {
            difficultyLevel = newLevel;
            Debug.Log("Difficulty level " + difficultyLevel);
        }
    }

    public int GetExtraEnemies()
    {
        return difficultyLevel * extraEnemiesPerLevel;
    }

    public float GetSpeedBonus()
    {
        return difficultyLevel * speedIncreasePerLevel;
    }
}
