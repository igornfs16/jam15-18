using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _housePrefab;
    [SerializeField] private Transform _startSpawnPoint;
    [SerializeField] private int _linesCount;
    [SerializeField] private int _startRaws;
    [SerializeField] private float _houseOffset;
    [SerializeField] private float _randomizeHouseOffset;
    [SerializeField] private float _distanceBetweenLines;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _ttlHouse;
    [SerializeField] private PlayerMover _playerMover;
    

    private Vector3 _currentSpawnPoint;
    private int _currentHouse;
    private float _currentDistance;
    private float _currentX;
    private float _currentZ;


    private void Awake()
    {
        _currentDistance = 0;
        _currentX = _startSpawnPoint.position.x;
        _currentZ = _startSpawnPoint.position.z;
    }

    void Start()
    {
        for(int y = 0; y <= _startRaws; y++)
        {
            for (int i = 0; i <= _linesCount; i++)
            {
                _currentX += _houseOffset + Random.Range(0, _randomizeHouseOffset);
                _currentZ += _distanceBetweenLines + Random.Range(0, _randomizeHouseOffset); 
                _currentSpawnPoint = new Vector3(_currentX, 0, _startSpawnPoint.position.z + _currentZ);
                SpawnHouse(_currentSpawnPoint);
            }
            _currentZ = _startSpawnPoint.position.z;
        }
    }

    
    void Update()
    {
        _currentDistance += _playerMover.CurrentSpeed() * Time.deltaTime;
        if (_currentDistance > _spawnDistance)
        {
            for (int i=0;i<=_linesCount;i++)
            {
                _currentX += _houseOffset + Random.Range(0, _randomizeHouseOffset);
                _currentZ += _distanceBetweenLines;
                _currentSpawnPoint = new Vector3(_currentX, 0,_startSpawnPoint.position.z + _currentZ);
                SpawnHouse(_currentSpawnPoint);
            }
        _currentZ = _startSpawnPoint.position.z;
        _currentDistance = 0;
        }
    }

    void SpawnHouse(Vector3 _spawnPoint)
    {
        _currentHouse = Random.Range(0, _housePrefab.Length);
        GameObject house = Instantiate(_housePrefab[_currentHouse] , _spawnPoint, Quaternion.identity);
        Destroy(house, _ttlHouse);
    }
}
