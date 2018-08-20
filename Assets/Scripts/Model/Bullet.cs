﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Geekbrains
{
    public class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            SetDamage(collision.collider.gameObject.GetComponent<ISetDamage>());
            Destroy(gameObject);
            var contact = collision.contacts[0];
            var temp = collision.collider.gameObject.GetComponent<BaseObjectScene>();
            if (temp != null)
                temp.CreateDecal(contact);

        }

        private void SetDamage(ISetDamage obj)
        {
            if (obj == null) return;

            obj.SetDamage(new InfoBulletCollision(_curentDamage, Rigidbody.velocity));
        }
    }
}