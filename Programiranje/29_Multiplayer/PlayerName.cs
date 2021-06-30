using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace com.PISMO.MultiplayerDodatna
{
    public class PlayerName : MonoBehaviour
    {
        string playerNamePrefKey = "Player";

        private void Start()
        {
            PhotonNetwork.NickName = playerNamePrefKey;
        }

        public void SetPlayerName(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player name not set");
                return;
            }

            PhotonNetwork.NickName = value;

            PlayerPrefs.SetString(playerNamePrefKey, value);
        }
    }
}

