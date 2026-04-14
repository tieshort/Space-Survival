using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyData> enemyOrderList;
    public Transform[] levelSpawnPoints;

    [SerializeField] private float startDelay = 5f;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float waveInterval = 5f;
    private float timer;

    private int currentWave = 0;
    private int maxWave;

    private EnemyData currentWaveData;
    private System.Random random;

    public int RemainingEnemies;

    private void Awake()
    {
        maxWave = enemyOrderList.Count;
        timer = startDelay;

        random = new System.Random();
        currentWaveData = enemyOrderList[currentWave];

        foreach(var enemyData in enemyOrderList)
        {
            RemainingEnemies += enemyData.count;
        }
    }

    private void Update()
    {
        if (currentWave == maxWave)
        {
            enabled = false;
            return;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        timer = spawnInterval;

        if (currentWaveData.count > 0)
        {
            SpawnEnemy();
            currentWaveData.count--;
            return;
        }

        NextWave();
    }

    private void NextWave()
    {
        currentWave++;
        if (currentWave == maxWave)
        {
            return;
        }

        currentWaveData = enemyOrderList[currentWave];
        timer = waveInterval;
    }

    private void SpawnEnemy()
    {
        int randomIndex = random.Next(levelSpawnPoints.Length);
        Transform spawnTransform = levelSpawnPoints[randomIndex];

        var enemy = Instantiate(currentWaveData.gameObject, spawnTransform.position, Quaternion.identity);
        if (enemy.TryGetComponent<Health>(out var health))
        {
            health.OnLethalDamage.AddListener(() => RemainingEnemies--);
        }
    }
}

[System.Serializable]
public struct EnemyData
{
    public GameObject gameObject;
    public int count;
}
