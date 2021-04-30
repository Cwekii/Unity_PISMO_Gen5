using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Share : MonoBehaviour
{
    //Twitter
    string Twitter_Adress = "https://twitter.com/intent/tweet";
    string tweet_Language = "en";
    string textToDisplay = "#SuckMyDick " + " Hey friends! Check out my score: "  + " in this dick sucking game";

    //Facebook
    string facebook_Adress = "https://www.facebook.com/dialog/feed?";
    string AppID = "23762215393"; //Morate svoji app id - https://developers.facebook.com/apps/
    string link = "https://www.youtube.com/watch?v=WOjl8c2Rp9o";
    string picture = "";
    string caption = "Check out my new score!";
    string description = "Enjoy fun, free games at pornhub.com";

    public void ShareOnTwitter()
    {
        Application.OpenURL(Twitter_Adress + "?text=" + UnityWebRequest.EscapeURL(textToDisplay) + "&amp;lang=" + tweet_Language);
    }

    public void ShareOnFacebook()
    {
        Application.OpenURL(facebook_Adress + "app_id=" + AppID + "&link=" + link + "&picture=" + picture
            + "&caption" + caption + PlayerPrefs.GetInt("Highscore").ToString() + "&description=" + UnityWebRequest.EscapeURL(description));
    }
}
