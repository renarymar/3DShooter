using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Geekbrains
{
    public abstract class Weapon : BaseObjectScene
    {
        [SerializeField] public Transform _barrel;
        [SerializeField] public float _force;
        [SerializeField] public float _rechargeTime;
        [SerializeField] public Ammunition Ammunition;


        protected Timer _timer = new Timer(); //переделать перезарядку
        protected bool _isFire = true;


        public abstract void Fire();

        protected virtual void Update()
        {
            _timer.Update();
            if (_timer.IsEvent())
            {
                _isFire = true;
            }
        }


    }
}