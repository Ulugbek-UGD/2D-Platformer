using UnityEngine;

namespace RedwoodTestTask
{
    public class DestroyByTime : MonoBehaviour
    {
        [SerializeField] private float time = 1;
        
        //============================================================
        private void Start()
        {
            Destroy(gameObject, time);
        }
        //============================================================
    }
}