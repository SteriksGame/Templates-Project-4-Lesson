using System;
using UnityEngine;
using Zenject;

public class MiniGameMainMenuHUD : MonoBehaviour
{
    public event Action StartedAllBallGameButton;
    public event Action StartedOnlyOneColorBallGameButton;

    private ISceneLoadMediator _sceneLoadMediator;

    [Inject]
    public void Contructor(ISceneLoadMediator sceneLoadMediator)
    {
        _sceneLoadMediator = sceneLoadMediator;
    }

    public void StartAllBallGameButton()
    {
        StartedAllBallGameButton?.Invoke();
        _sceneLoadMediator.GoToMiniGame(new LevelLoadingData(new AllBallGameMode()));
    }

    public void StartOnlyOneColorBallGameButton()
    {
        StartedOnlyOneColorBallGameButton?.Invoke();
        _sceneLoadMediator.GoToMiniGame(new LevelLoadingData(new OnlyOneColorBallGameMode()));
    }
}