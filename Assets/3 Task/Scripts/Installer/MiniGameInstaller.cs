using UnityEngine;
using Zenject;

public class MiniGameInstaller : MonoInstaller
{
    [SerializeField] private MiniGameResultMenuHUD _resultHUD;

    private LevelLoadingData _levelLoadingData;

    [Inject]
    public void Construct(LevelLoadingData levelLoadingData)
    {
        _levelLoadingData = levelLoadingData;
    }

    public override void InstallBindings()
    {
        BindMiniGameHUD();
        BindBallGenerator();
        BindGameModeController();
        BindLevelData();
    }

    private void BindMiniGameHUD() => Container.Bind<MiniGameResultMenuHUD>().FromInstance(_resultHUD).AsSingle();

    private void BindGameModeController()
    {
        Container.Bind<GameController>().AsSingle();

        Container.Bind<GameModeSwitcher>().AsSingle().NonLazy();
    }

    private void BindBallGenerator()
    {
        Container.Bind<BallGenerator>().AsSingle();

        Container.Bind<BallFactory>().AsSingle();
    }

    private void BindLevelData()
    {
        Container.Bind<LevelLoadingData>().FromInstance(_levelLoadingData);
    }
}
