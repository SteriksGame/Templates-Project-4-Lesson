using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Factory/EnemySpawnerConfig")]
public class EnemySpawnerConfig : ScriptableObject
{
    [SerializeField, Range(0, 10)] private float _spawnCooldown;

    public float SpawnCooldown => _spawnCooldown;
}
