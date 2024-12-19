using UnityEngine;
using System;

namespace RedwoodTestTask
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private PlayerData playerData;
        
        public static event Action OnDead;
        
        //============================================================
        private void Start()
        {
            playerData.ResetData();
        }
        //============================================================
        public void ApplyDamage(int damage, GameObject pest = null)
        {
            if (playerData.currentHealth > 0)
            {
                playerData.currentHealth -= damage;
                
                if(playerData.currentHealth <= 0)
                {
                    playerData.currentHealth = 0;
                    playerData.isAlive = false;
                    OnDead?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
        //============================================================
    }
}