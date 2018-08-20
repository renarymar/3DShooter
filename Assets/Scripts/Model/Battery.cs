using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Battery : MonoBehaviour
    {

        public float BatteryLevel;

        private void Awake()
        {
            //изначальный заряд батареи
            BatteryLevel = 100;
        }
    }
}