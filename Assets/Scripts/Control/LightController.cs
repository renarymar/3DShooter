using UnityEngine;

namespace Geekbrains
{
	public class LightController :BaseController
	{
		private FlashLight _flashLight;
		private FlashLightUi _flashLightUi;

        private void Start()
        {
            _flashLight = FindObjectOfType<FlashLight>();
            _flashLight.Switch(false);
            _flashLightUi = FindObjectOfType<FlashLightUi>();
        }

        private void Update()
        {
            if (!IsActive) return;
            _flashLight.Rotation();


        }

        public override void On()
        {
            if (IsActive) return;
            base.On();
            _flashLight.Switch(true);
            _flashLightUi.SetActive(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLight.Switch(false);
            _flashLightUi.SetActive(false);
        }

        public void Switch()
        {
            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }
}