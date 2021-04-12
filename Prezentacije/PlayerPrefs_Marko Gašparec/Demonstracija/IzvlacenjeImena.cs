using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IzvlacenjeImena : MonoBehaviour
{
    public TMP_Text textUKojemTrebaBitImeIzInputFielda;

    private void Start()
    {
        textUKojemTrebaBitImeIzInputFielda.text = PlayerPrefs.GetString("ime");
    }
}
