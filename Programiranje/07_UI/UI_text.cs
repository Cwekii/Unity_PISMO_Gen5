using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_text : MonoBehaviour
{
    public Text textic;
    int brojac;

    private void Update()
    {
        brojac+= 109;
        textic.text = brojac + "$";
    }
}
