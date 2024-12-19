using UnityEngine;

namespace RedwoodTestTask
{
    public interface IDamageable
    {
        //============================================================
        public void ApplyDamage(int damage, GameObject pest = null);
        //============================================================
    }
}