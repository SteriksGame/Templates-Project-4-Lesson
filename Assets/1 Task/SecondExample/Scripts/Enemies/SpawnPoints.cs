using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;

    public Vector3 GetRandomPoint() => _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
}
