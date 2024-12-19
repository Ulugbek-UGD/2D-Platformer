using UnityEngine;

namespace RedwoodTestTask
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        
        private static float moveX => PlayerInputs.Move.ReadValue<float>();
        
        private Rigidbody2D body2D;
        
        //============================================================
        private void Awake()
        {
            body2D = GetComponent<Rigidbody2D>();
        }
        //============================================================
        private void FixedUpdate()
        {
            body2D.linearVelocityX = moveX * playerData.moveSpeed;
            
            playerData.velocityX = Mathf.Clamp(body2D.linearVelocityX / playerData.moveSpeed, -1, 1);
            
            if (Mathf.Abs(playerData.velocityX) > 0)
            {
                switch (playerData.velocityX)
                {
                    case > 0:
                        transform.eulerAngles = Vector3.zero;
                        playerData.facingDirection = PlayerData.FacingDirection.Right;
                        break;
                    
                    case < 0:
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        playerData.facingDirection = PlayerData.FacingDirection.Left;
                        break;
                }
            }
            else
            {
                transform.eulerAngles = playerData.facingDirection == PlayerData.FacingDirection.Right
                    ? Vector3.zero
                    : new Vector3(0, 180, 0);
            }
        }
        //============================================================
        private void Update()
        {
            playerData.position = transform.position;
        }
        //============================================================
    }
}