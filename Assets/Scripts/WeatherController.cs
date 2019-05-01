using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    private Light light;
    private bool nighttime;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (!nighttime)
        {
            light.intensity -= 0.01f * Time.deltaTime;
            if (light.intensity == 0)
            {
                nighttime = true;
            }
        }
        else {
            light.intensity += 0.01f * Time.deltaTime;
            if (light.intensity >= 1) {
                nighttime = false;
            }
        }
    }
}
