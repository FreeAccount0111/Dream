using System;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class SheepReturnByDistance : MonoBehaviour
    {
        [SerializeField] private float amountX;

        private void Update()
        {
            if (transform.position.x > amountX)
            {
                ObjectPool.Instance.Return(gameObject,true);
            }
        }
    }
}
