using Gameplay.Events;
using Gameplay.Model;
using UI.Gameplay;
using UnityEngine;
using Zenject;

namespace Gameplay.Presenter
{
    public class GameplayPresenter
    {
        private IGameplayView _view;
        private PlayerModel _model;
        
        [Inject]
        public GameplayPresenter(IGameplayView view, PlayerModel model)
        {
            _view = view;
            _model = model;

            GameEvent.OnCountSheep += CountSheep;
            GameViewEvent.UpdateCountSheep += UpdateCountSheep;
            GameViewEvent.UpdateTime += UpdateTime;
        }
        
        public void Dispose()
        {
            GameEvent.OnCountSheep -= CountSheep;
            GameViewEvent.UpdateCountSheep -= UpdateCountSheep;
            GameViewEvent.UpdateTime -= UpdateTime;
        }

        private void CountSheep()
        {
            _model.ExecuteSheep();
        }

        private void UpdateTime(int second)
        {
            _view.UpdateTime(second);
        }

        private void UpdateCountSheep(int amount)
        {
            _view.UpdateCountSheep(amount);
        }
        
    }
}
