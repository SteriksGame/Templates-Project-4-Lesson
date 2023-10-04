using System.Collections.Generic;

public class GameController
{
    private BallGenerator _ballGenerator;

    private MiniGameResultMenuHUD _resultHUD;

    private List<Ball> _ballsInGame;
    private IGameMode _gameMode;

    private MiniGameInputController _miniGameInputController;

    public GameController(MiniGameInputController miniGameInputController, BallGenerator ballGenerator, 
        MiniGameResultMenuHUD resultHUD, LevelLoadingData levelLoadingData)
    {
        _miniGameInputController = miniGameInputController;
        _ballGenerator = ballGenerator;

        _resultHUD = resultHUD;

        _gameMode = levelLoadingData.GameMode;

        Play();
    }

    public void SetGameMode(IGameMode gameMode) => _gameMode = gameMode;

    public void Play()
    {
        _ballsInGame = _ballGenerator.Generate();

        foreach (Ball ball in _ballsInGame)
            ball.DestroyedBall += OnBallDestroyed;

        _miniGameInputController.IsActiv = true;
    }

    private void OnBallDestroyed(Ball ball)
    {
        ball.DestroyedBall -= OnBallDestroyed;
        _ballsInGame.Remove(ball);

        if (_gameMode.IsWin(_ballsInGame))
        {
            _resultHUD.SetActionResultView(true);
            _miniGameInputController.IsActiv = false;
        }
    }
}