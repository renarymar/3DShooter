using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Geekbrains
{
    public class Grenade : Ammunition
    {
        
        private void OnCollisionEnter(Collision collision)
        {
            SetDamage(collision.collider.gameObject.GetComponent<ISetDamage>());
            Destroy(gameObject);
        }

        private void SetDamage(ISetDamage obj)
        {
            if (obj == null) return;

            obj.SetDamage(new InfoBulletCollision(_curentDamage, Rigidbody.velocity));
        }
    }
}