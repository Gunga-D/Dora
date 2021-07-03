using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesRegulator : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private WaveCounter _waveCounter;

    private Bank _bank;

    private EnemiesSpawner _originator;
    private WaveDeterminant _wave;
    private GiverWaveStartOpportunity _waveStartOpportunity;
    private EnemyModificationsAdder _statBooster;

    private int _amountSpawnEnemies;
    private List<Enemy> _enemiesOnScene = new List<Enemy>();

    private void Start()
    {
        _bank = _hero.GetComponentInChildren<Bank>();

        _originator = GetComponentInChildren<EnemiesSpawner>();
        _wave = GetComponentInChildren<WaveDeterminant>();
        _waveStartOpportunity = GetComponentInChildren<GiverWaveStartOpportunity>();
        _statBooster = GetComponentInChildren<EnemyModificationsAdder>();

        _waveStartOpportunity.SetOpportunityFor(() => StartCoroutine(StartWave()));
    }

    private void Update()
    {
        if (_waveStartOpportunity.TryToGive(IsWaveEnded()))
        {
            _enemiesOnScene.Clear();
        }
    }

    private IEnumerator StartWave()
    {
        _waveCounter.UpdateValue(_wave.Level);

        _amountSpawnEnemies = 0;
        float currentDuration = 0;

        while (_wave.Duration > currentDuration)
        {
            _amountSpawnEnemies++;
            Enemy instance = _originator.Spawn(_wave.Difficulty);

            _statBooster.Upgrade(instance, _wave.EnemyLevels);

            instance.RemovedFromGameBoard += OnRemovingEnemy;
            _enemiesOnScene.Add(instance);

            float spawnDelay = Random.Range(0.45f, 1f);
            currentDuration += spawnDelay;

            yield return new WaitForSeconds(spawnDelay);
        }

        _wave.IncreaseWaveNumber();
    }

    private void OnRemovingEnemy(Enemy obj)
    {
        _bank.Deposit(obj.Cost);

        _amountSpawnEnemies--;
        _enemiesOnScene.Remove(obj);

        OnDisableEnemyEvent(obj);
    }

    private void OnDisableEnemyEvent(Enemy obj)
    {
        obj.RemovedFromGameBoard -= OnRemovingEnemy;
    }

    private bool IsWaveEnded()
    {
        return _amountSpawnEnemies <= 0;
    }

    public void NullifyWaves()
    {
        _wave.RestartWaveNumber();

        foreach (var enemy in _enemiesOnScene)
        {
            Destroy(enemy.gameObject);
        }

        _amountSpawnEnemies = 0;

        _waveCounter.UpdateValue(0);
    }
}
