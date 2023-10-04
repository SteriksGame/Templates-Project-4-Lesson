using System;
using UnityEngine;
using Zenject;

public class MiniGameResultMenuHUD : MonoBehaviour
{
    public event Action EnteredMainMenuButton;

    [SerializeField] private GameObject _resultView;

    private ISceneLoadMediator _sceneLoadMediator;

    [Inject]
    public void Contructor(ISceneLoadMediator sceneLoadMediator)
    {
        _sceneLoadMediator = sceneLoadMediator;
    }

    public void SetActionResultView(bool value) => _resultView.SetActive(value);

    public void EnterMainMenuButton()
    {
        EnteredMainMenuButton?.Invoke();
        _sceneLoadMediator.GoToMainMenu();
    }
}