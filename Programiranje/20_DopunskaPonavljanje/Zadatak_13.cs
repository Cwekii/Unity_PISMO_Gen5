using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Napravite na sceni lika koji se krece sa W, A, S, D.
Nije bitna perspektiva niti način kretanja.
Bitno je da se na tipku "Space" spremi njegova pozicija i 
sa ponovnim pokretanjem igre on krene od te pozicije.
Malo postavite neke oblike po sceni da vam bude lakše
prepoznati jel se spremilo ili nije.
*/

public class Zadatak_13 : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SavePosition();
        }
    }

    void SavePosition()
    {
        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.SetFloat("posZ", transform.position.z);
    }
}
