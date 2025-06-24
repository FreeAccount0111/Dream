using Gameplay.Controllers.Sheep;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class SpawnSheepController : MonoBehaviour
    {
        [SerializeField] private Transform posSpawn;

        private Vector3 GetRandomPositionSpawn()
        {
            var randomY = UnityEngine.Random.Range(-2f, 2f);
            return new Vector3(posSpawn.position.x, randomY, randomY);
        }
        
        public void SpawnNewSheep()
        {
            var newSheep = ObjectPool.Instance.Get(ObjectPool.Instance.sheep).GetComponent<SheepController>();
            newSheep.transform.position = GetRandomPositionSpawn();
            newSheep.Initialized();
        }
    }
}
