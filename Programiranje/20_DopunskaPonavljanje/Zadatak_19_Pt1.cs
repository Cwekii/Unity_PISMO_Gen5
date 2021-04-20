using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite statičnu klasu koja ce u sebe pohranjivati sustav saveanja playerove pozicije.

public static class Zadatak_19_Pt1
{
    public static float posX = PlayerPrefs.GetFloat("pozcijaX");
    public static float posY = PlayerPrefs.GetFloat("pozcijaY");
    public static float posZ = PlayerPrefs.GetFloat("pozcijaZ");
    public static Vector3 positione = new Vector3(posX, posY, posZ);

    public static void SavePositions(Vector3 pozicija)
    {
        PlayerPrefs.SetFloat("pozcijaX", pozicija.x);
        PlayerPrefs.SetFloat("pozcijaY", pozicija.y);
        PlayerPrefs.SetFloat("pozcijaZ", pozicija.z);
    }
}
