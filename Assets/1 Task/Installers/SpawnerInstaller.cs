using UnityEngine;
using Zenject;

public class SpawnerInstaller : MonoInstaller
{
    [SerializeField] private SpawnPoints _spawnPoints;
    [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;

    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();

        Container.Bind<SpawnPoints>().FromInstance(_spawnPoints).AsSingle();

        Container.Bind<EnemySpawnerConfig>().FromInstance(_enemySpawnerConfig).AsSingle();

        Container.Bind<EnemySpawner>().AsSingle();
    }
}
