using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolDefaultCapacity = 10;
    [SerializeField] private int _poolMaxSize = 20;

    private int _currentPointNumber = 0;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (obj) => ActionOnGet(obj),
        actionOnRelease: (obj) => obj.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolDefaultCapacity,
        maxSize: _poolMaxSize);
    }

    private void Start()
    {
        SpawnAtAllPoints();
    }

    public void SpawnAtAllPoints()
    {
        while (_currentPointNumber < _spawnPoints.Count)
        {
            _pool.Get();
        }
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.transform.position = _spawnPoints[_currentPointNumber].position;
        _currentPointNumber++;
        obj.SetActive(true);
    }
}
