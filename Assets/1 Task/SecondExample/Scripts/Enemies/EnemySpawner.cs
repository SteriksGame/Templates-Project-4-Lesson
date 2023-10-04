using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : IPause
{
    private float _spawnCooldown;

    private List<Enemy> _spawnedEnemies = new List<Enemy>();

    private EnemyFactory _enemyFactory;
    private PauseHandler _pauseHandler;
    private SpawnPoints _spawnPoints;

    private MonoBehaviour _context;
    private Coroutine _spawn;

    private bool _isPaused;

    public EnemySpawner(EnemyFactory enemyFactory, PauseHandler pauseHandler,  EnemySpawnerConfig enemySpawnerConfig, SpawnPoints spawnPoint)
    {
        _enemyFactory = enemyFactory;
        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);

        _spawnPoints = spawnPoint;

        _context = spawnPoint;

        _spawnCooldown = enemySpawnerConfig.SpawnCooldown;
    }

    public void StartWork()
    {
        StopWork();

        _spawn = _context.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _context.StopCoroutine(_spawn);
    }

    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;

        foreach (Enemy enemy in _spawnedEnemies)
            enemy.SetPause(isPaused);
    }

    private IEnumerator Spawn()
    {
        float time = 0;

        while (true)
        {
            while(time < _spawnCooldown)
            {
                if(_isPaused == false)
                    time += Time.deltaTime;

                yield return null;
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints.GetRandomPoint());
            _spawnedEnemies.Add(enemy);
            time = 0;
        }
    }
}
