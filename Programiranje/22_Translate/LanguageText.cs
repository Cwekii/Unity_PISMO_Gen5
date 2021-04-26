using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{
    public string textKey;

    private void Start()
    {
        Text textic = GetComponent<Text>();
        if(textic != null)
        {
            if(textic.text == "ISOcode")
            {
                textic.text = LanguageTranslation.GetLanguage();
            }
            else
            {
                textic.text = LanguageTranslation.Fields[textKey];
            }
        }
    }
}
