using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public struct InfoWeaponCollision
    {
        private readonly float _damage;

        public InfoWeaponCollision(float damage)
        {
            _damage = damage;
        }

        public float Damage
        {
            get
            {
                return _damage;
            }
        }
    }
}