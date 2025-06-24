using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Controllers.Sheep
{
    public class SheepController : MonoBehaviour
    {
        [SerializeField] private SheepAnimator sheepAnimator;
        [SerializeField] private SheepMovement sheepMovement;

        public void Initialized()
        {
            
        }
    }
}
