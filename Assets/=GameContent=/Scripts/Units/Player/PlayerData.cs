using UnityEngine;

namespace RedwoodTestTask
{
    [CreateAssetMenu(menuName = "Game Data/Player Data", fileName = "New Player Data")]
    public class PlayerData : ScriptableObject
    {
        public string _name = "Player";
        
        [Space(10)]
        [Range(0, 100)] public int maxHealth = 100;
        public int currentHealth = 100;
        public bool isAlive = true;
        
        [Space(10)]
        [Range(0.1f, 0.3f)]public float fireRate = 0.15f;
        public int ammoCount = 30;
        public bool isFire;
        
        [Space(10)]
        public FacingDirection facingDirection;
        public enum FacingDirection { Right, Left }
        [Range(2, 12)] public float moveSpeed = 8;
        public float velocityX;
        
        [Space(10)]
        public Vector2 position;
        
        //============================================================
        public void ResetData()
        {
            _name = "Player";
            
            maxHealth = 100;
            currentHealth = maxHealth;
            isAlive = true;
            
            fireRate = 0.14f;
            ammoCount = 30;
            isFire = false;
            
            facingDirection = FacingDirection.Right;
            moveSpeed = 8;
            velocityX = 0;
            
            position = Vector2.zero;
        }
        //============================================================
    }
}