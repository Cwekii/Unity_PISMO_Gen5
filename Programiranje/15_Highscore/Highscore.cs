using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    // WEB: http://dreamlo.com/lb/no2V9wAQg02E5Vc5z8ooRwW8am8_ZcYUqrfDKzd546LQ
    //podatke za doljne stringove upisujemo sa stranice dremlo.com
    //const služi kako se ta varijabla nebi više mjenjala nigdje
    const string privateCode = "no2V9wAQg02E5Vc5z8ooRwW8am8_ZcYUqrfDKzd546LQ";
    const string publicCode = "6062df0c8f421366b05680f5";
    //Napomena - Ne možete koristi http linkove na Androidu ako je API level 9.0 ili više i uopće na iOS-u
    const string webURL = "http://dreamlo.com/lb/";

    [Header("Player input")]
    [SerializeField] InputField playerName;
    public string userNick;

    public DisplayHighscore displayHighscore;
    highscore[] highscoreList;

    private void Awake()
    {
        //Provjera u playerPrefsu imamo li to ime već na igraču, odnosno ima li igrač ime
        userNick = PlayerPrefs.GetString("PlayerUsername");
        displayHighscore = GetComponent<DisplayHighscore>();
    }
    private void Start()
    {
        //Ako user već nije upisao ime
        if(userNick == string.Empty) //userNick == null
        {
            userNick = "Player" + Random.Range(0, 1000000).ToString();
        }
    }

    //Igrač je upisao novo ime i želi sa tim novim imenom uploadati svoj score
    public void ChangeDateByMe()
    {
        if(playerName.text != string.Empty)
        {
            //učitamo ime iz inputa
            userNick = playerName.text;
            //Spremi ime u playerPrefs
            PlayerPrefs.SetString("PlayerUsername", userNick);
            //Dodjeli highscore
            int maxScore = PlayerPrefs.GetInt("Highscore");
            //Dodaj novi highscore
            AddNewHighscore(userNick, maxScore);
            //Prikaži sustav sada kad smo stavili novi highscore
            displayHighscore.myHighscore.text = userNick + " - " + PlayerPrefs.GetInt("Highscore");
        }
    }

    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoreFromDatebase());
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        //Na koju konekciju (na koji link) šaljemo zahtjev
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

        //Ako je zahtjev uspješan - nemamo error
        if(string.IsNullOrEmpty(www.error)) //www.error == null
        {
            Debug.Log("Upload Successffull");
            //Vrati nam listu highscorova
            DownloadHighscores();
        }

        //Ako je zahtjev failao i imamo error
        else
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }

    IEnumerator DownloadHighscoreFromDatebase()
    {
        UnityWebRequest www = new UnityWebRequest(webURL + publicCode + "/pipe/");
        /*
         * DownloadHandlerBuffer nam služi za preuzimanje podata u bajtovima u Unity
         * potom te podatke pakira u cijelu u našoj memoriji
         * Napomena - dok se skida je u RAM memoriji, tek kad se skine sve se složi u cijeli i stavlja na disk
         */
        DownloadHandlerBuffer dh = new DownloadHandlerBuffer();

        www.downloadHandler = dh;

        yield return www.SendWebRequest();

        //Ako je uspješno preuzeto
        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download successfull");
            Debug.Log(www.downloadHandler.text); // 1
            //Formatirnje teksta
            FormatHighscore(www.downloadHandler.text);
            //Prikaz skinutog texta u UI u unityu
            displayHighscore.ShowOnTextWhenHighscoresDownloaded(highscoreList);
        }

        //Ako je neuspješno i nije preuzeto
        else
        {
            Debug.Log("Error downloading: " + www.error);
        }
    }

    //Formatiranje skinutog sadržaja
    void FormatHighscore(string textStream)
    {
        //Slaži podatke u array tako da razvajaš u novi red
        string[] entires = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        //stvori array dužine
        highscoreList = new highscore[entires.Length];

        for (int i = 0; i < entires.Length; i++)
        {
            //Razdvojiti sve podatke svakoga reda sa znakom "|" (taj znak možete vidjeti u debugu kada ste imali ispis preuzetog) //1
            string[] entryInfo = entires[i].Split(new char[] { '|' });
            //učitati prvi razdvojeni podatak
            string username = entryInfo[0];
            //učitati drugi razdvojeni podatak
            int score = int.Parse(entryInfo[1]); // string kurac = "9312073081" moze pretvoriti u int

            //popuni array za prikaz sa podatcima
            //highscoreList[i] = new highscore(entryInfo[0], int.Parse(entryInfo[1]);
            highscoreList[i] = new highscore(username, score);
        }
    }

    //Jedan blok memorije, a može mu se pristupiti iz više izvora i načina
    public struct highscore
    {
        public string username;
        public int score;

        public highscore(string usernameInput, int scoreInput)
        {
            this.username = usernameInput;
            this.score = scoreInput;
        }
    }
}
