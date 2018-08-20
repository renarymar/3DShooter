using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Ammunition : BaseObjectScene
    {
        [SerializeField] private float _timeToDestroy;
        [SerializeField] private float _baseDamage;
        protected float _curentDamage;

        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, _timeToDestroy);
            _curentDamage = _baseDamage; //как будет меняться урон
        }

    }
}
