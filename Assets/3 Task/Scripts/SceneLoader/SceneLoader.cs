using System;

public class SceneLoader : ISimpleSceneLoader, ILevelLoader
{
    private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void Load(SceneID sceneID)
    {
        if (sceneID == SceneID.Play)
            throw new ArgumentException($"{SceneID.Play} cannot be starter without configuration");

        _zenjectSceneLoader.Load(null, (int)sceneID);
    }

    public void Load(LevelLoadingData levelLoadingData)
    {
        _zenjectSceneLoader.Load(container => 
        { 
            container.BindInstance(levelLoadingData).WhenInjectedInto<MiniGameInstaller>();
        }, (int)SceneID.Play);
    }
}