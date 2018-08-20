using System;
using UnityEngine;
using Assets.Scripts.Helpers;

namespace Geekbrains
{
    public class Box : BaseObjectScene, ISetDamage
    {
        
        [SerializeField] public float HP;
        [SerializeField] public int force;
        [SerializeField] public float destroyTime;

        public void SetDamage(InfoBulletCollision info)
        {
            if (HP > 0)
            {
                HP -= info.Damage;
            }

            if (HP <= 0)
            {
                HP = 0;
                Color = Color.red;
                var tempRB = GetComponent<Rigidbody>();
                if (!tempRB)
                {
                    tempRB = gameObject.AddComponent<Rigidbody>();
                }

                tempRB.AddForce(info.Dir * force);
                Destroy(gameObject, destroyTime);
            }
        }
    }
}
