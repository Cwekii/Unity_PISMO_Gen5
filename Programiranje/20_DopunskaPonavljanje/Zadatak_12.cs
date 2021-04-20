using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Na sceni napravite audioSource i jedan UI Slider.
Napravite skriptu da je jačina audioSourcea povezana 
sa vrijednošću slidera.
Dakle ako je slider value 0.5 onda je i volume
na audioSourceu 0.5.
No bitna je stvar da se jačina zvuka (slidera) 
sprema u player prefs tako da igraču ostane
jačina zvuka kakvu je htio.
*/

public class Zadatak_12 : MonoBehaviour
{
    public AudioSource sourscici;
    public Slider slidercici;

    private void Start()
    {
        slidercici.value = PlayerPrefs.GetFloat("volume");
        //sourscici.volume = slidercici.value;
        sourscici.volume = PlayerPrefs.GetFloat("volume");
    }

    public void ChangedAudioVolumen()
    {
        sourscici.volume = slidercici.value;
        PlayerPrefs.SetFloat("volume", slidercici.value);
    }
}
