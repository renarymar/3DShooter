﻿using UnityEngine;

namespace Geekbrains
{
	public class Main : MonoBehaviour
	{
		private GameObject _allControllers;

		public LightController LightController { get; private set; }
		public InputController InputController { get; private set; }
		public WeaponController WeaponController { get; private set; }
        public Inventory Inventory { get; private set; }

		public static Main Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
			_allControllers = new GameObject("AllControllers");
			InputController = _allControllers.AddComponent<InputController>();
			LightController = _allControllers.AddComponent<LightController>();
			WeaponController = _allControllers.AddComponent<WeaponController>();
            Inventory = _allControllers.AddComponent<Inventory>();
		}
	}
}