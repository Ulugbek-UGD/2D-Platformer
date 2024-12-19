using UnityEngine;

namespace RedwoodTestTask
{
    public class Zombie : MonoBehaviour, IDamageable
    {
        [SerializeField] private float moveSpeed = 3;
        
        [Space(10)]
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private GameObject lootOnDeath;
        
        private int currentHealth;
        
        private Rigidbody2D body2D;
        private SpriteHealthBar healthBar;
        
        //============================================================
        private void Awake()
        {
            body2D = GetComponent<Rigidbody2D>();
            healthBar = GetComponentInChildren<SpriteHealthBar>();
        }
        //============================================================
        private void Start()
        {
            currentHealth = maxHealth;
        }
        //============================================================
        private void FixedUpdate()
        {
            body2D.linearVelocityX = transform.right.x * moveSpeed;
        }
        //============================================================
        public void ApplyDamage(int damage, GameObject pest)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damage;
                
                if(currentHealth <= 0)
                {
                    currentHealth = 0;
                    Instantiate(lootOnDeath, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                
                healthBar.DisplayHealth(currentHealth, maxHealth);
            }
        }
        //============================================================
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(100, gameObject);
            }
        }
        //============================================================
    }
}