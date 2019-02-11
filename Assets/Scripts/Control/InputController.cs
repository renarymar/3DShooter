using UnityEngine;

namespace Geekbrains
{
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Main.Instance.LightController.Switch();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetWeapon(1);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetWeapon(0);
            }

        }

        private void SetWeapon(int i)
        {
            Main.Instance.WeaponController.Off();
            var tempWeapon = Main.Instance.Inventory.Weapons[i];
            if (tempWeapon != null) Main.Instance.WeaponController.On(tempWeapon);
        }
    }
}