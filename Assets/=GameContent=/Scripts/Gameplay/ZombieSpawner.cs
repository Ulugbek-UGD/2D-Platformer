using UnityEngine;

namespace RedwoodTestTask
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] zombies;
        [SerializeField] private Transform[] spawnPoints;
        
        [Space(10)]
        [SerializeField, Range(4, 10)] private float maxSpawnTime = 5;
        [SerializeField] private Transform spawnContainer;
        
        //============================================================
        private void Start()
        {
            Spawn();
        }
        //============================================================
        private void Spawn()
        {
            var randomTime = Random.Range(0, maxSpawnTime);
            var randomPoint = Random.Range(0, spawnPoints.Length);
            var randomZombie = Random.Range(0, zombies.Length);
            
            Instantiate(zombies[randomZombie], spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation, spawnContainer);
            
            Invoke(nameof(Spawn), randomTime);
        }
        //============================================================
        private void OnDestroy()
        {
            CancelInvoke(nameof(Spawn));
        }
        //============================================================
    }
}