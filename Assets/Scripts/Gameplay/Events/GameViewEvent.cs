using System;
using UnityEngine;

namespace Gameplay.Events
{
    public class GameViewEvent
    {
        public static event Action<int> UpdateCountSheep;
        public static event Action<int> UpdateTime;

        public static void RaiseUpdateCountSheep(int amount) => UpdateCountSheep?.Invoke(amount);
        public static void RaiseUpdateTime(int second) => UpdateTime?.Invoke(second);
    }
}
