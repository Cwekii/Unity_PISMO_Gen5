using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Text textic;
    bool Activate = true;

    private void Update()
    {
        textic.text = "Loading...";
        textic.color = new Color(Mathf.PingPong(Time.time, 1), Mathf.PingPong(Time.time, 1),
            Mathf.PingPong(Time.time, 1), Mathf.PingPong(Time.time, 1));
        if(Activate == true)
        {
            StartCoroutine(LoadSceneAsyncNow());
            Activate = false;
        }
    }

    IEnumerator LoadSceneAsyncNow()
    {
        AsyncOperation async;
        if (PlayerPrefs.GetInt("scene") == 0)
        {
            async = SceneManager.LoadSceneAsync(1);
        }
        else
        {
            async = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("scene"));
        }
        

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
