
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _enemyCount = 5;
    [SerializeField] private Transform _spawnTopLeft, _spawnTopRight, _spawnBottomLeft, _spawnBottomRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int extra = 0;
        if(DifficultyManager.instance != null)
        {
            extra = DifficultyManager.instance.GetExtraEnemies();
        }
        // int totalEnemies = _enemyCount + extra;
        for(int i=0; i < _enemyCount; i++)
        {
            SpawnEnemy();
        }

    }

    private int lastDifficultyLevel = 0;
    void Update()
    {
        if(DifficultyManager.instance == null) 
        return;
        int currentLevel = DifficultyManager.instance.difficultyLevel;
        if(currentLevel > lastDifficultyLevel)  
        {
            int difference = currentLevel - lastDifficultyLevel;
            for (int i=0; i<difference; i++)
            {
                SpawnEnemy();
            }
            lastDifficultyLevel = currentLevel;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 SpawnPosition = SelectRandomPosition();
        GameObject enemyObject = Instantiate(_enemyPrefab, SpawnPosition, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.onDie += SpawnEnemy;
        }
    }

    private Vector3 SelectRandomPosition()
    {
        Transform selectedTransform = null;
        int randomValue = Random.Range(0,4);
        SpawnPointType spawnType = (SpawnPointType)randomValue;

        switch (spawnType)
        {
            case SpawnPointType.TopLeft: {selectedTransform = _spawnTopLeft;
            break;}
            case SpawnPointType.TopRight: {selectedTransform = _spawnTopRight;
            break;}
            case SpawnPointType.BottomLeft: {selectedTransform = _spawnBottomLeft;
            break;}
            case SpawnPointType.BottomRight: {selectedTransform = _spawnBottomRight;
            break;}
            default: { selectedTransform = _spawnTopLeft;
            break;}
        }
        return selectedTransform.position + (Vector3)Random.insideUnitCircle;
    }

}
public enum SpawnPointType
{
    TopLeft = 0,
    TopRight = 1,
    BottomLeft = 2,
    BottomRight = 3
}
