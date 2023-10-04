using System;
using Zenject;
using UnityEngine.SceneManagement;

public class ZenjectSceneLoaderWrapper
{
    private readonly ZenjectSceneLoader _zenjectSceneLoader;

    public ZenjectSceneLoaderWrapper(ZenjectSceneLoader loader)
    {
        _zenjectSceneLoader = loader;
    }

    public void Load(Action<DiContainer> action, int sceneID)
     => _zenjectSceneLoader.LoadScene(sceneID, LoadSceneMode.Single, contaiter => action?.Invoke(contaiter));
}