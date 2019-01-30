using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSettings : MonoBehaviour {

    [SerializeField] Color Sky, Equator, Ground, SunColor;
    [SerializeField] float RotateSpeed;
    Light Sun;

    private void Start()
    {
        Sun = GetComponent<Light>();
    }

    private void Update()
    {
        RenderSettings.ambientSkyColor = Sky;
        RenderSettings.ambientGroundColor = Ground;
        RenderSettings.ambientEquatorColor = Equator;
        Sun.color = SunColor;
        transform.Rotate(transform.right, RotateSpeed, Space.Self);
    }
}
