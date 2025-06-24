using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Controllers
{
    public class FenceController : MonoBehaviour
    {
        [SerializeField] private int widthFence;
        [SerializeField] private SpriteRenderer fenceTop;
        [SerializeField] private SpriteRenderer fenceBody;
        [SerializeField] private SpriteRenderer fenceBottom;

        [SerializeField] private BoxCollider2D col;

        private void UpdateFence()
        {
            fenceBody.size = new Vector2(0.2f, 0.525f * widthFence);
            
            if (widthFence > 0)
            { 
                fenceTop.transform.localPosition = (widthFence + 1) * 0.5f * new Vector2(0, 0.525f);
                fenceBottom.transform.localPosition = (widthFence + 1) * 0.5f * new Vector2(0, -0.525f);

                col.size = new Vector2(0.2f,  (widthFence + 2) * 0.5f);
            }
            else
            {
                fenceTop.transform.localPosition = new Vector3(0, 0.25f, 0);
                fenceBottom.transform.localPosition = new Vector3(0, -0.25f, 0);

                col.size = new Vector2(0.2f, 1f);
            }
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            UpdateFence();
        }
#endif
    }
}
