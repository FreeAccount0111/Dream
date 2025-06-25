using Gameplay.Model;
using Gameplay.Presenter;
using UI.Gameplay;
using UnityEngine;
using Zenject;

namespace Gameplay.Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameplayView gameView;
        public override void InstallBindings()
        {
            Container.Bind<IGameplayView>().FromInstance(gameView).AsSingle();
            Container.Bind<PlayerModel>().AsSingle();
        }
    }
}
