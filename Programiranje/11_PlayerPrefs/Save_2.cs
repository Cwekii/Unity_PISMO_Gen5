using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_2 : MonoBehaviour
{
    float score = 0;
    public Text scorere;
    public string playerName;

    protected void Start()
    {
        score = PlayerPrefs.GetFloat("rez" + playerName);
        scorere.text = score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            score += 0.5f;
            scorere.text = score.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            score -= 0.5f;
            scorere.text = score.ToString();
        }
    }

    public void QuickSave()
    {
        PlayerPrefs.SetFloat("rez" + playerName, score);
    }
}
