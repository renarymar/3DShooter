using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class Battery : MonoBehaviour
    {

        [SerializeField] [Range(0, 100)] public float BatteryLevel;
    }
}