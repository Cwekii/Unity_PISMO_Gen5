using UnityEngine;
using UnityEngine.Advertisements;

public class rewardVideoAd : MonoBehaviour, IUnityAdsListener
{
    [SerializeField]
    string gameID;
    bool testMode = true;
    [SerializeField]
    string myPlacementId = "rewardedVideo";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, testMode);
    }

    public void ShowRewardedVideo()
    {
        if(Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video se nije mogao učitati, probaj opet jebe* ti");
        }
    }

    //Video se nije učitao - greška
    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error: " + message);
    }

    //Video se uspješno POGLEDAO ili je video završio
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //Ako je uspješno pogledan video
        if(showResult == ShowResult.Finished)
        {
            //Nagradi igrača sa npr povećanim scorom, dodatnim životom ili tako nešto
        }
        else if(showResult == ShowResult.Skipped)
        {
            //Nemoj nagraditi korisnika i j*** mu mat** jer je skipao ad
        }
        else if(showResult == ShowResult.Failed)
        {
            //Ovisi o vama, može se desiti da je igraču zaštekalo, ali i u tom slčaju vi niste dobili novce za reklamu, tako da pazite hoće li nagraditi igrača ili ne
        }
    }

    //Kada se reklama (Ad) pokrene
    public void OnUnityAdsDidStart(string placementId)
    {
        //Možete nagraditi korisnika jer je pokrenuo, možete zaustaviti igru jer mu traje reklama, može napraviti ništa
    }

    //Provjera jel sve spremno za dom
    public void OnUnityAdsReady(string placementId)
    {
        if(placementId == myPlacementId)
        {
            //Sve je okej
        }
        else
        {
            placementId = myPlacementId;
        }
    }
}
