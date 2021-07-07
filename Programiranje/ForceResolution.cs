using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResolution : MonoBehaviour
{
    public GameObject canvas16_9;
    public GameObject canvas16_10;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //9:16
        if(Screen.height / Screen.width > 1.7f && Screen.height / Screen.width < 1.8f)
        {
            Screen.SetResolution(1080, 1920, true);
            canvas16_9.SetActive(true);
        }
        //10:16
        if(Screen.height / Screen.width == 1.6f)
        {
            Screen.SetResolution(800, 1280, true);
        }
        //4:3
        //18:9
    }
}
