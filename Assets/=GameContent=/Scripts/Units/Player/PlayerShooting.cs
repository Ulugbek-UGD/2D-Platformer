using UnityEngine.InputSystem;
using UnityEngine;

namespace RedwoodTestTask
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        
        [Space(10)]
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform firePoint;
        [SerializeField] private AudioClip fireSound;
        
        private AudioSource audioSource;
        
        //============================================================
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
        //============================================================
        private void OnEnable()
        {
            PlayerInputs.Fire.started += OnFireInputDown;
            PlayerInputs.Fire.canceled += OnFireInputUp;
        }
        //============================================================
        private void OnDisable()
        {
            PlayerInputs.Fire.started -= OnFireInputDown;
            PlayerInputs.Fire.canceled -= OnFireInputUp;
        }
        //============================================================
        private void OnFireInputDown(InputAction.CallbackContext context)
        {
            Fire();
        }
        //============================================================
        private void Fire()
        {
            if (playerData.ammoCount <= 0) return;
            
            playerData.isFire = true;
            playerData.ammoCount--;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.volume = Random.Range(0.4f, 0.5f);
            audioSource.PlayOneShot(fireSound);
            
            if (playerData.ammoCount > 0)
            {
                Invoke(nameof(Fire), playerData.fireRate);
            }
            else
            {
                playerData.isFire = false;
            }
        }
        //============================================================
        private void OnFireInputUp(InputAction.CallbackContext context)
        {
            playerData.isFire = false;
            CancelInvoke(nameof(Fire));
        }
        //============================================================
    }
}