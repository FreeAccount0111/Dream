using System;
using System.Collections.Generic;
using Gameplay.Controllers.Sheep;
using Gameplay.Manager;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float radius;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                List<SheepController> sheepScared = SheepManager.Instance.GetSheepScared(point,radius);
                foreach (var sheep in sheepScared)
                {
                    Vector2 direction = (Vector2)sheep.transform.position - (Vector2)point;
                    sheep.Scared((Vector2)point + direction.normalized * (radius + 0.1f));
                }
            }
        }
    }
}
