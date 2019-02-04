using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Geekbrains
{
    public class WizardWeapon : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            SetWeaponDamage(collision.collider.gameObject.GetComponent<ISetWeaponDamage>());
        }

        private void SetWeaponDamage(ISetWeaponDamage obj)
        {
            if (obj == null) return;

            obj.SetWeaponDamage(new InfoWeaponCollision(_curentDamage));
        }
    }
}