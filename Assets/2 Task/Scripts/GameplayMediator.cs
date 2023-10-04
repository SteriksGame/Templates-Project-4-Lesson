using System;

public class GameplayMediator : IDisposable
{
    private DefeatPanel _defeatPanel;

    private Level _level;

    public GameplayMediator(Level level, DefeatPanel defeatPanel)
    {
        _level = level;
        _level.Defeat += OnLevelDefeat;

        _defeatPanel = defeatPanel;
        _defeatPanel.Restarted += RestartLevel;
    }

    public void Dispose()
    {
        _level.Defeat -= OnLevelDefeat;

        _defeatPanel.Restarted -= RestartLevel;
    }

    private void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }

    private void OnLevelDefeat() => _defeatPanel.Show();
}
