using UnityEngine;

namespace RedwoodTestTask
{
    public class ParallaxLayer : MonoBehaviour
    {
        public float parallaxFactor;
        
        //============================================================
        public void Move(Vector2 direction)
        {
            var newPos = transform.localPosition;
            newPos.x -= direction.x * parallaxFactor;
            newPos.y -= direction.y * parallaxFactor;
            transform.localPosition = newPos;
        }
        //============================================================
    }
}