using Assets.Scripts.Helpers;
using UnityEngine;

namespace Geekbrains
{
	public class WeaponController : BaseController
	{
		private Weapon _weapon;
		private int _mouseButton = (int) MouseButton.LeftButton;
		private void Update()
		{
			if(!IsActive) return;

            if (Input.GetMouseButton(_mouseButton) || Input.GetKeyDown(KeyCode.Q))
			{
				_weapon.Fire();
			}
		}

		public void On(Weapon weapon)
		{
			if (IsActive) return;
			base.On();

			_weapon = weapon;
			_weapon.IsVisible = true;
		}

		public override void Off()
		{
			if (!IsActive) return;
			base.Off();

			_weapon.IsVisible = false;
			_weapon = null;
		}
	}
}