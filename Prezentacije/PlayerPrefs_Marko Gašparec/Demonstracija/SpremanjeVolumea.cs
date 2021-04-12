using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpremanjeVolumea : MonoBehaviour
{
    public Slider sliderGlasnoce;

    private void Start()
    {
        sliderGlasnoce.value = PlayerPrefs.GetFloat("sliderMuzike");
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("sliderMuzike", sliderGlasnoce.value);
    }
}
