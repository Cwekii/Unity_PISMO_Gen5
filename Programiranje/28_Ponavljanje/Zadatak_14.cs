using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_14 : MonoBehaviour
{
    AudioSource ass;

    private void Start()
    {
        ass = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            ass.Play();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ass.Pause();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ass.UnPause();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(ass.mute)
            {
                ass.mute = false;
            }
            else if(!ass.mute)
            {
                ass.mute = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ass.Stop();
        }
    }
}
