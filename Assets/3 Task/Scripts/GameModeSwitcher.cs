public class GameModeSwitcher
{
    private GameController _gameController;

    public GameModeSwitcher(GameController gameController, LevelLoadingData levelLoadingData)
    {
        _gameController = gameController;

        _gameController.SetGameMode(levelLoadingData.GameMode);
    }

    public void SetAllBallGame()
    {
        _gameController.SetGameMode(new AllBallGameMode());
    }

    public void SetOnlyOneColorBallGame()
    {
        _gameController.SetGameMode(new OnlyOneColorBallGameMode());
    }
}
