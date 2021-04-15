using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Napravite na sceni jedan cube koji ima tag "Player"
 * i jednu sferu koja ima tag "Sfera". Na oba objekta stavite rigidbody
 * i isključite gravitaciju. Napišite skriptu koja ispisuje u debugu kada
 * je cube ušao u sferu, kada je unutra i kada je izašao.
 * Testirate ju tako što vi tokom play modea pomićete cube u sferu i van.
 */

public class Zadatak_2 : MonoBehaviour
{
    //OVA SKRIPTA MORA BITI NA CUBE OBJEKTU SA TAGOM PLAYER
    private void OnTriggerEnter(Collider drugiColliderKojiDodirne)
    {
        if(drugiColliderKojiDodirne.gameObject.tag == "Sfera")
        {
            Debug.Log("Ušao");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Sfera")
        {
            Debug.Log("Unutra");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sfera")
        {
            Debug.Log("Vani");
        }
    }
}
