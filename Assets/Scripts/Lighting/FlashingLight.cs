using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    private Light _light;
    private bool _increasing;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_increasing)
            _light.intensity += 1 * Time.deltaTime;
        else
            _light.intensity -= 1 * Time.deltaTime;

        if (_light.intensity <= 0)
            _increasing = true;
        if (_light.intensity >= 1)
            _increasing = false;
    }
}
