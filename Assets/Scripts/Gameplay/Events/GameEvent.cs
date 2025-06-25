using System;
using UnityEngine;

namespace Gameplay.Events
{
    public class GameEvent
    {
        public static event Action OnStartGame;
        public static event Action OnStopGame;
        public static event Action OnCountSheep;

        public static void RaiseCountSheep() => OnCountSheep?.Invoke();
        public static void RaiseStartGame() => OnStartGame?.Invoke();
        public static void RaiseStopGame() => OnStopGame?.Invoke();
    }
}
