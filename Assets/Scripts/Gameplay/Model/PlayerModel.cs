using Gameplay.Events;

namespace Gameplay.Model
{
    public class PlayerModel
    {
        private int _countSheep;
        private int _coinPlayer;

        public int CountSheep => _countSheep;

        public void ExecuteSheep()
        {
            _countSheep += 1;
            GameViewEvent.RaiseUpdateCountSheep(_countSheep);
        }

        private void AddCoinPlayer(int amount)
        {
            _coinPlayer += amount;
        }

        private void RemoveCoinPlayer(int amount)
        {
            
        }
    }
}
