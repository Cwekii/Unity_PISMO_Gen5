using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Spremanje : MonoBehaviour
{
    public TMP_InputField mjestoZaTekst;

    public void SpremanjeImenaIPokretanjeIgre()
    {
        PlayerPrefs.SetString("ime", mjestoZaTekst.text);
        SceneManager.LoadScene("Game");
    }
}
