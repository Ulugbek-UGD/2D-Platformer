using UnityEngine.UI;
using UnityEngine;

namespace RedwoodTestTask
{
    public class PlayerAmmoUI : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        
        private Text ammoCount;
        
        //============================================================
        private void Awake()
        {
            ammoCount = GetComponent<Text>();
        }
        //============================================================
        private void Update()
        {
            ammoCount.text = playerData.ammoCount.ToString();
        }
        //============================================================
    }
}