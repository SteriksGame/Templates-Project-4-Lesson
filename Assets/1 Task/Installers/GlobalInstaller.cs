using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
        BindLoader();
    }

    private void BindInput()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
        else
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();

        Container.BindInterfacesAndSelfTo<MiniGameInputController>().AsSingle();
    }

    private void BindLoader()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoadMediator>().AsSingle();
    }
}