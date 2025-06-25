using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Controllers;
using Gameplay.Controllers.Sheep;
using Gameplay.Events;
using UnityEngine;

namespace Gameplay.Manager
{
    public class SheepManager : MonoBehaviour
    {
        public static SheepManager Instance;
        [SerializeField] private List<SheepController> sheepInMap = new List<SheepController>();
        [SerializeField] private Transform posSpawn;

        private Coroutine _coroutine;
        
        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            GameEvent.OnStartGame += StartSpawn;
            GameEvent.OnStopGame += StopSpawn;
        }

        private void OnDisable()
        {
            GameEvent.OnStartGame -= StartSpawn;
            GameEvent.OnStopGame -= StopSpawn;
        }

        private void StartSpawn()
        {
            _coroutine = StartCoroutine(SpawnCoroutine());
        }

        IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                SpawnNewSheep();
                yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1f));
            }
        }

        private void StopSpawn()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private Vector3 GetRandomPositionSpawn()
        {
            var randomY = UnityEngine.Random.Range(-4f, 4f);
            return new Vector3(posSpawn.position.x, randomY, randomY);
        }
        
        public void SpawnNewSheep()
        {
            var newSheep = ObjectPool.Instance.Get(ObjectPool.Instance.sheep).GetComponent<SheepController>();
            newSheep.transform.position = GetRandomPositionSpawn();
            newSheep.Initialized();
            
            sheepInMap.Add(newSheep);
        }
        
        public List<SheepController> GetSheepScared(Vector2 pos,float radius)
        {
            List<SheepController> sheepScared = new List<SheepController>();
            for (int i = 0; i < sheepInMap.Count; i++)
            {
                if (Vector2.Distance(pos, sheepInMap[i].transform.position) < radius)
                {
                    sheepScared.Add(sheepInMap[i]);
                }
            }

            return sheepScared;
        }
    }
}
