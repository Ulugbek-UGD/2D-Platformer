using System.Collections.Generic;
using UnityEngine;

namespace RedwoodTestTask
{
    public class ParallaxController : MonoBehaviour
    {
        private PlayerCamera playerCamera;
        
        private readonly List<ParallaxLayer> parallaxLayers = new();
        
        //============================================================
        private void Awake()
        {
            if (Camera.main != null)
            {
                playerCamera = Camera.main.GetComponent<PlayerCamera>();
            }
            SetLayers();
        }
        //============================================================
        private void OnEnable()
        {
            playerCamera.OnCameraTranslate += Move;
        }
        //============================================================
        private void OnDisable()
        {
            playerCamera.OnCameraTranslate -= Move;
        }
        //============================================================
        private void SetLayers()
        {
            parallaxLayers.Clear();
            
            for (var i = 0; i < transform.childCount; i++)
            {
                var layer = transform.GetChild(i).GetComponent<ParallaxLayer>();
                if (layer != null)
                { 
                    parallaxLayers.Add(layer);
                }
            }
        }
        //============================================================
        private void Move(Vector2 direction)
        {
            foreach (var layer in parallaxLayers)
            {
                layer.Move(direction);
            }
        }
        //============================================================
    }
}