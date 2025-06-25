using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay
{
    public class GameplayView : MonoBehaviour,IGameplayView
    {
        [SerializeField] private Text textCountSheep;
        [SerializeField] private Text txtTime;
        
        public void UpdateCountSheep(int amount)
        {
            textCountSheep.text = amount.ToString();
        }

        public void UpdateTime(int second)
        {
            txtTime.text = $"{second / 60:00}:{second % 60:00}";
        }

        public void UpdateCoin(int amount)
        {
            
        }
    }
}
