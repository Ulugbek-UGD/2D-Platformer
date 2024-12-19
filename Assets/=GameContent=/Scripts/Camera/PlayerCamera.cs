using UnityEngine;
using System;

namespace RedwoodTestTask
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform player;
        
        [Space(10)]
        [SerializeField] private float speed = 3;
        [SerializeField] private Vector3 offset = new(0, 7, -10);
        
        [Space(10)]
        [SerializeField] private Camera_Bounds cameraBounds;
        
        public event Action<Vector2> OnCameraTranslate;
        
        private Vector2 oldCameraPosition;
        
        //============================================================ Set camera to Camera_Bounds
        private void Awake()
        {
            cameraBounds.Initialize(GetComponent<Camera>());
        }
        //============================================================ Cache this camera position
        private void Start()
        {
            oldCameraPosition = transform.position;
        }
        //============================================================ This camera translate event
        private void Update()
        {
            if ((Vector2)transform.position != oldCameraPosition)
            {
                var direction = new Vector2(oldCameraPosition.x - transform.position.x,
                    oldCameraPosition.y - transform.position.y);
                OnCameraTranslate?.Invoke(direction);
            }
            oldCameraPosition = transform.position;
        }
        //============================================================ Camera follow
        private void LateUpdate()
        {
            if (!player) return;
            
            cameraBounds.CalculateBounds();
            
            var desiredPosition = new Vector3(
                Mathf.Clamp(player.position.x + offset.x, cameraBounds.maxXLimit.x, cameraBounds.maxXLimit.y),
                Mathf.Clamp(player.position.y + offset.y, cameraBounds.maxYLimit.x, cameraBounds.maxYLimit.y),
                transform.position.z);
            
            var smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            
            transform.position = smoothPosition;
        }
        //============================================================
    }
}