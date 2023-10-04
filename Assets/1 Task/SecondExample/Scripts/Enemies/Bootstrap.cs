using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private EnemySpawner _spawner;

    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler, EnemySpawner enemySpawner)
    {
        _pauseHandler = pauseHandler;
        _spawner = enemySpawner;
    }

    private void Awake()
    {
        _spawner.StartWork();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _pauseHandler.SetPause(true);

        if (Input.GetKeyDown(KeyCode.S))
            _pauseHandler.SetPause(false);
    }
}
