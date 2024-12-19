using UnityEngine;

namespace RedwoodTestTask
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage = 30;
        [SerializeField] private float flySpeed = 30;
        [SerializeField] private GameObject impactVFX;
        
        private Rigidbody2D body2D;
        
        //============================================================
        private void Awake()
        {
            body2D = GetComponent<Rigidbody2D>();
        }
        //============================================================
        private void FixedUpdate()
        {
            body2D.linearVelocityX = transform.right.x * flySpeed;
        }
        //============================================================
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(damage, gameObject);
            }
            
            Instantiate(impactVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        //============================================================
    }
}