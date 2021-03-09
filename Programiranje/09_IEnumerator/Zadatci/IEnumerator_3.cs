using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ienumeratorcic : MonoBehaviour
{
    public Text prefab;
    void Start()
    {
        Debug.Log("start");
        StartCoroutine(SpounaPrmtv());
    }


    IEnumerator SpounaPrmtv()
    {
        yield return new WaitForSeconds(10);
        prefab.text = "Brao!";
    }
}