using UnityEngine;

namespace Gameplay.Controllers.Sheep
{
    public class SheepAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private const string SHEEP_IDLE = "Idle";
        private const string SHEEP_JUMP = "Jump";

        public void PlayAnimationIdle()
        {
            PlayAnimationByName(SHEEP_IDLE);
        }

        public void PlayAnimationJump()
        {
            PlayAnimationByName(SHEEP_JUMP);
        }

        private void PlayAnimationByName(string nameAnimation, float duration = 0)
        {
            animator.CrossFade(nameAnimation, 0);
        }
    }
}
