using Zenject;
using System;
using UnityEngine;
using System.IO;

public class BallFactory
{
    private const string BallConfig = "BallCollectionConfig";
    private const string ConfigPath = "BallConfigs";

    private BallFactoryConfig _config;

    private DiContainer _container;

    public BallFactory(DiContainer container)
    {
        _container = container;

        Load();
    }

    public int CountCollection => _config.BallCollection.Count;

    public Ball Get(int indexBall)
    {
        if(indexBall < 0 || indexBall > _config.BallCollection.Count - 1)
            throw new ArgumentOutOfRangeException(nameof(indexBall));

        return _container.InstantiatePrefabForComponent<Ball>(_config.BallCollection[indexBall]);
    }

    private void Load()
    {
        _config = Resources.Load<BallFactoryConfig>(Path.Combine(ConfigPath, BallConfig));
    }
}
