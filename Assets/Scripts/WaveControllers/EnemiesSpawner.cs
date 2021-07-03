using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemiesSpawner : GameObjectCreator
{
    [SerializeField] private List<EnemyConfig> _enemies = new List<EnemyConfig>();
    private EnemyPositionDisposer _positionPublisher;

    private void Start()
    {
        _positionPublisher = GetComponent<EnemyPositionDisposer>();
    }

    public Enemy Spawn(int difficulty)
    {
        List<EnemyConfig> soughtEnemies = _enemies.Where(x => x.EnemyDifficulty == difficulty).ToList();
        EnemyConfig soughtEnemy = soughtEnemies.ElementAt(Random.Range(0, soughtEnemies.Count));

        Enemy instance = CreateGameObject<Enemy>(soughtEnemy.Prefab);
        instance.transform.position = _positionPublisher.GetFreePosition();

        return instance;
    }
}
