using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Za koristiti ovu skriptu morate imati Native Share Plugin iz Asset Storea
//https://assetstore.unity.com/packages/tools/integration/native-share-for-android-ios-112731
public class ShareUltimateButton : MonoBehaviour
{
    [SerializeField] GameObject screenSHootPanel;

    public void OnShare()
    {
        screenSHootPanel.SetActive(true);
        StartCoroutine(TakeScreenshotAndShareIt());
    }

    IEnumerator TakeScreenshotAndShareIt()
    {
        yield return new WaitForSeconds(0.5f);
        //ss skraceno za ScreenShoot
        //Novo koristeno TextureFormat.RGBA32
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared_img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Highscore Cool Game").
            SetText("Check out my New HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString()).Share();
        screenSHootPanel.SetActive(false);
    }
}
