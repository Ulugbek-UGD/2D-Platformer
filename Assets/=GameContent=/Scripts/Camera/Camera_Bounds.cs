using UnityEngine;

namespace RedwoodTestTask
{
    public class Camera_Bounds : MonoBehaviour
    {
        public Vector2 bound = new(10, 10);
        public Vector2 offset;
        
        public Vector2 maxXLimit { get; private set; }
        public Vector2 maxYLimit { get; private set; }
        
        private Camera _camera;
        
        //============================================================
        public void Initialize(Camera newCamera)
        {
            _camera = newCamera;
            CalculateBounds();
        }
        //============================================================
        public void CalculateBounds()
        {
            var cameraHalfWidth = _camera.aspect * _camera.orthographicSize;
            var position = transform.position;
            maxXLimit = new Vector2(position.x + offset.x - bound.x / 2 + cameraHalfWidth, position.x + offset.x + bound.x / 2 - cameraHalfWidth);
            maxYLimit = new Vector2(position.y + offset.y - bound.y / 2 + _camera.orthographicSize, position.y + offset.y + bound.y / 2 - _camera.orthographicSize);
        }
        //============================================================
    }
}