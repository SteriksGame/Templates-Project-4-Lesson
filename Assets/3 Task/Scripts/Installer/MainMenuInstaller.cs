using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] private MiniGameMainMenuHUD _mainMenuHUD;

    public override void InstallBindings()
    {
        Container.Bind<MiniGameMainMenuHUD>().FromInstance(_mainMenuHUD).AsSingle();

        // Остальные бинды в глобал инсталлере
    }
}