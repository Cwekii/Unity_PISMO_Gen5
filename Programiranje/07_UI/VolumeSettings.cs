using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioSource ass;
    public Slider slid;
    public Text btnSoundText;
    public Button btn;
    public Color cl;

    private void Start()
    {
        slid.value = ass.volume;
        if (ass.isPlaying == true)
        {
            btnSoundText.text = "ON";
            var btnColors = btn.colors;
            btnColors.selectedColor = Color.green;
        }
        else
        {
            btnSoundText.text = "OFF";
            var btnColors = btn.colors;
            btnColors.selectedColor = Color.red;
        }

    }

    public void ChangeAudio()
    {
        ass.volume = slid.value;
    }

    public void OnOffAudio()
    {
        var btnColors = btn.colors;
        if (ass.isPlaying == true)
        {
            ass.Stop();
            btnSoundText.text = "OFF";
            btnColors.selectedColor = Color.red;

        }
        else
        {
            ass.Play();
            btnSoundText.text = "ON";
            btnColors.selectedColor = Color.green;

        }
    }
}
