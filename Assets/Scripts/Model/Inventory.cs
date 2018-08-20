﻿using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Geekbrains
{
    public class Inventory : MonoBehaviour
    {
        private Weapon[] _weapons;
        private Transform _firstPersonController;

        public Weapon[] Weapons
        {
            get
            {
                return _weapons;
            }
        }

        //расширить возможности инвентаря
        private void Awake()
        {
            _firstPersonController = FindObjectOfType<FirstPersonController>().transform;
            _weapons = _firstPersonController.GetComponentsInChildren<Weapon>();

            foreach (var weapon in _weapons)
            {
                weapon.IsVisible = false;
            }
        }
    }
}