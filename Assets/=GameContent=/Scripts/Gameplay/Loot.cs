using UnityEngine;

namespace RedwoodTestTask
{
    public class Loot : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        
        [Space(10)]
        [SerializeField, Range(1, 20)] private int maxValue = 8;
        [SerializeField] private GameObject lootSoundPrefab;
        
        private int randomAmmo;
        
        //============================================================
        private void Start()
        {
            randomAmmo = Random.Range(1, maxValue);
            GetComponentInChildren<TextMesh>().text = randomAmmo.ToString();
        }
        //============================================================
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerData.ammoCount += randomAmmo;
                Instantiate(lootSoundPrefab);
                Destroy(gameObject);
            }
        }
        //============================================================
    }
}