public class LevelLoadingData
{
    private IGameMode _gameMode;

    public LevelLoadingData(IGameMode gameMode)
        => _gameMode = gameMode;

    public IGameMode GameMode => _gameMode;
}