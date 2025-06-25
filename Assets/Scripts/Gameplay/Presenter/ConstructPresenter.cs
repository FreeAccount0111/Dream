using Gameplay.Model;
using UI.Gameplay;
using UnityEngine;
using Zenject;

namespace Gameplay.Presenter
{
    public class ConstructPresenter : MonoBehaviour
    {
        private GameplayPresenter _gameplayPresenter;
        private IGameplayView _gameplayView;
        private PlayerModel _playerModel;

        [Inject]
        private void InitializedPresenter(IGameplayView gameplayView,PlayerModel playerModel)
        {
            _gameplayView = gameplayView;
            _playerModel = playerModel;

            _gameplayPresenter = new GameplayPresenter(gameplayView, _playerModel);
        }
    }
}
