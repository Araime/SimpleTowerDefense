using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _points;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(SpawnDelay(_spawnDelay, _enemyCount));
    }

    /// <summary>
    /// Spawn an enemy and give them route points
    /// </summary>
    private void SpawnEnemy()
    {
        GameObject Enemy = Instantiate(_enemyPrefab, _points[0].position, Quaternion.identity);
        if (Enemy.TryGetComponent(out Enemy enemy))
        {
            enemy.Init(_points);
        }
    }

    /// <summary>
    /// Creates a set number of enemies with a set delay
    /// </summary>
    /// <param name="time"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    private IEnumerator SpawnDelay(float time, int count)
    {
        while(count > 0)
        {
            SpawnEnemy();
            count--;
            yield return new WaitForSeconds(time);
        }
    }
}
