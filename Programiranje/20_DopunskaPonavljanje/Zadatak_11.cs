using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Napravite na sceni 1 text i 3 gumba
Na tekstu se prikazuju bodovi. Sa pritiskom miša
na prvi gumb, bodovi porastu za 1.
Sa pritiskom miša na drugi gumb bodovi se smanje za 1.
Sa pritiskom miša na treci gumb, spreme se bodovi
u Player Prefs.
Bodovi se NE SMIJU spremati kad god se povećaju
ili smanje nego isključivo kada se pritisne
treći gumb (button).
*/

public class Zadatak_11 : MonoBehaviour
{
    private int bodovi;
    public Text bodoviText;

    private void Start()
    {
        bodovi = PlayerPrefs.GetInt("bodovi");
        bodoviText.text = bodovi.ToString();
    }

    public void DodajBodova()
    {
        bodovi++;
        bodoviText.text = bodovi.ToString();
    }

    public void OduzmiBodove()
    {
        bodovi--;
        bodoviText.text = bodovi.ToString();
    }

    public void Sejvaj()
    {
        PlayerPrefs.SetInt("bodovi", bodovi);
    }
}
