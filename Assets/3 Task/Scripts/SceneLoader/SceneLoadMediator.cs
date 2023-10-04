public class SceneLoadMediator : ISceneLoadMediator
{
    private ISimpleSceneLoader _sceneLoader;
    private ILevelLoader _levelLoader;

    public SceneLoadMediator(ISimpleSceneLoader sceneLoader, ILevelLoader levelLoader)
    {
        _sceneLoader = sceneLoader;
        _levelLoader = levelLoader;
    }

    public void GoToMainMenu() => _sceneLoader.Load(SceneID.MainMenu);

    public void GoToMiniGame(LevelLoadingData levelLoadingData) => _levelLoader.Load(levelLoadingData);
}

