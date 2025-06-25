using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Controllers
{
    public class FenceControllerV2 : MonoBehaviour
    {
        [SerializeField] private int index;

        [SerializeField] private GameObject column;
        [SerializeField] private List<GameObject> lsColumns = new List<GameObject>();
        [SerializeField] private BoxCollider2D fenceCollider;

        private int _indexColumn;
        [SerializeField] private float amountColumn;

        [ContextMenu("Initialized")]
        private void UpdateFence()
        {
            _indexColumn = index * 4;
            
            if (lsColumns.Count > _indexColumn)
            {
                for (int i = _indexColumn; i < lsColumns.Count; i++)
                    Destroy(lsColumns[i].gameObject);
                lsColumns.RemoveRange(_indexColumn, lsColumns.Count - _indexColumn);
            }
            
            for (int i = lsColumns.Count; i < _indexColumn; i++)
            {
                var newColumn = Instantiate(column);
                lsColumns.Add(newColumn);
            }
            

            for (int i = 0; i < lsColumns.Count; i++)
            {
                lsColumns[i].transform.SetParent(this.transform);
                lsColumns[i].transform.localPosition = index % 2 == 0
                    ? new Vector3(0, (i - _indexColumn / 2) * amountColumn, (i - _indexColumn / 2) * amountColumn)
                    : new Vector3(0, (i - _indexColumn / 2) * amountColumn - amountColumn/2, (i - _indexColumn / 2) * amountColumn - amountColumn/2);
            }

            fenceCollider.size = new Vector2(0.15f, index * 0.6f + 0.15f);
        }
    }
}
