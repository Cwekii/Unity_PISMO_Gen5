using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzvlacenjeVolumea : MonoBehaviour
{
    public AudioSource mjestoDiJeMuzika;
    private void Start()
    {
        mjestoDiJeMuzika.volume = PlayerPrefs.GetFloat("sliderMuzike");
    }
}
