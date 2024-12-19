using UnityEngine;

namespace RedwoodTestTask
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        
        [Space(10)]
        [SerializeField] private Animator muzzleFlash;
        
        private Animator animator;
        private static readonly int velocityX = Animator.StringToHash("Velocity X");
        private static readonly int shooting = Animator.StringToHash("Shooting");
        
        //============================================================
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        //============================================================
        private void Update()
        {
            animator.SetFloat(velocityX, Mathf.Abs(playerData.velocityX));
            animator.SetBool(shooting, playerData.isFire);
            muzzleFlash.SetBool(shooting, playerData.isFire);
        }
        //============================================================
    }
}