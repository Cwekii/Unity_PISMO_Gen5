using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_8 : MonoBehaviour
{
    public int scale;

    private void Start()
    {
        for (int i = 0; i < scale; i++)
        {
            transform.localScale -= new Vector3(0, 1, 1);
        }
    }
}
