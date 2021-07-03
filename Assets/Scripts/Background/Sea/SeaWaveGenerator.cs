using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWaveGenerator : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _minSeaWaveSpeed;
    [SerializeField] private float _maxSeaWaveSpeed;
    [SerializeField] Transform _startPoint;
    [SerializeField] Transform _endPoint;
    [SerializeField] SeaWave _prefab;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(_startPoint.position.x, _endPoint.position.x), Random.Range(_startPoint.position.y, _endPoint.position.y), _startPoint.position.z);

        SeaWave currentSeaWave = Instantiate(_prefab, position, Quaternion.identity);

        float speed = Random.Range(_minSeaWaveSpeed, _maxSeaWaveSpeed);
        currentSeaWave.Initialize(speed);
    }

    private IEnumerator StartSpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
