using System;
using System.Collections;
using Gameplay.Events;
using Gameplay.Model;
using UI;
using UnityEngine;
using Zenject;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int secondGame;
        [Inject] private PlayerModel model;
        private void Awake()
        {
            CircleOutline.Instance.ScaleOut();
            StartGame();
        }

        private void StartGame()
        {
            GameEvent.RaiseStartGame();
            StartCoroutine(StartGameCoroutine());
        }

        private void StopGame()
        {
            GameEvent.RaiseStopGame();
            
            PopupCtrl.Instance.GetPopupByType<PopupWin>().UpdateScore(model.CountSheep);
            PopupCtrl.Instance.GetPopupByType<PopupWin>().ShowImmediately(true);
        }

        IEnumerator StartGameCoroutine()
        {
            while (secondGame>0)
            {
                secondGame -= 1;
                GameViewEvent.RaiseUpdateTime(secondGame);
                yield return new WaitForSeconds(1);
            }
            
            StopGame();
        }
    }
}
