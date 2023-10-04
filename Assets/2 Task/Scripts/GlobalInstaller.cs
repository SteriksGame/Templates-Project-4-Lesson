using UnityEngine;
using Zenject;

namespace Mediator
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private DefeatPanel _defeatPanel;

        public override void InstallBindings()
        {
            BindLevel();

            BindMediator();            
        }

        private void BindMediator()
        {
            Container.Bind<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();

            Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle();
        }

        private void BindLevel()
        {
            Container.Bind<Level>().AsSingle();

            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle().NonLazy();
        }
    }
}