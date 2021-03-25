using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProScript : MonoBehaviour
{
    public TMP_Text textic;
    int broj = 0;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            broj++;
            textic.text = broj.ToString();
        }
    }
}
