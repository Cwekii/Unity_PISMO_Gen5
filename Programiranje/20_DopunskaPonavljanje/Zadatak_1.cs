using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.) Napišite skriptu koja može pomicati kocku po svim osima (javne varijable),
//rotirati (javne varijable) i povećavati (javne varijable) svake sekunde.

public class Zadatak_1 : MonoBehaviour
{
    //public float posX, posY, posZ, rotX, rotY, rotZ, scaleX, scaleY, scaleZ;

    public float posX, posY, posZ;
    public float rotX, rotY, rotZ;
    public float scaleX, scaleY, scaleZ;

    private void Update()
    {
        //Pomicanje
        transform.position += new Vector3(posX, posY, posZ) * Time.deltaTime;
        //Rotiranje
        transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.deltaTime);
        //Scale
        transform.localScale += new Vector3(scaleX, scaleY, scaleZ) * Time.deltaTime;
    }
}
