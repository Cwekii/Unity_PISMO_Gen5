using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool loadScene = false;
    public int sceneNumber;
    bool callMethod = true;
    public Text loadingText;

    //void Start()
    //{
    //    loadScene = false;
    //}

    void Update()
    {
        if (loadScene == true)
        {
            loadingText.text = "Loading...";
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
            if(callMethod == true)
            {
                StartCoroutine(LoadSceneAsyncNow());
                callMethod = false;
            }
        }

    }


    public void StartGame()
    {
        loadScene = true;

        StartCoroutine(LoadSceneAsyncNow());
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneAsyncNow()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneNumber);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}