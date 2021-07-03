using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _minCloudSpeed;
    [SerializeField] private float _maxCloudSpeed;
    [SerializeField] private List<Cloud> _prefabs;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private void Spawn()
    {
        int prefabIndex = Random.Range(0, _prefabs.Count);
        Cloud currentCloud = Instantiate(_prefabs[prefabIndex]);

        Vector3 position = new Vector3(_startPoint.position.x, Random.Range(_startPoint.position.y, _endPoint.position.y), _startPoint.position.z);
        currentCloud.transform.position = position;

        float speed = Random.Range(_minCloudSpeed, _maxCloudSpeed);
        currentCloud.Initialize(speed);

        float lifeTime = Vector3.Distance(_startPoint.position, _endPoint.position) / speed;
        currentCloud.SetDestruction(lifeTime);
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
