using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLanguage : MonoBehaviour
{
    public string jezik = "en";

    public void KlikniDaPromjenisJezik()
    {
        PlayerPrefs.SetString("Language", jezik);
        Debug.Log("Saveano u playerPrefs");

        LanguageTranslation.LoadLangugae();
        Debug.Log("Uspiješno loadano");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restiraj scenu da se prikaže jezik
        Debug.Log("Resetirano");
    }
}
