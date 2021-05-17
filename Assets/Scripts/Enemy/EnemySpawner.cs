using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawns;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0f;

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawns)
        {
            if (TryGetEnemy(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

                DisableObjectAbroadCamera();
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }
}
