using UnityEngine;

namespace Gameplay.Controllers.Sheep
{
    public class SheepAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void PlayAnimationByName(string nameAnimation, float duration = 0)
        {
            animator.CrossFade(nameAnimation, 0);
        }
    }
}
