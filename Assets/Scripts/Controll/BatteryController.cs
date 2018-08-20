using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class BatteryController : BaseController
    {
        private Battery _battery;
        private FlashLightUi _flashLightUi;
        private FlashLight _flashlight;

        private void Start()
        {
            _flashlight = FindObjectOfType<FlashLight>();
            _flashLightUi = FindObjectOfType<FlashLightUi>();
            _battery = FindObjectOfType<Battery>();
        }

        private void Update()
        {
            //расход заряда
            if (_flashLightUi != null && _flashlight.Light.enabled) 
                _flashLightUi.TextB = (_battery.BatteryLevel -= Time.deltaTime);

            //восстановление заряда
            if (!_flashlight.Light.enabled && _battery.BatteryLevel <100) 
                _flashLightUi.TextB = (_battery.BatteryLevel += Time.deltaTime);
        }
    }
}
