using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace com.PISMO.MultiplayerDodatna
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        [Tooltip("The maximum number of player per room. When room is full, it can not be joind by other, so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 4;

        string gameVersion = "1";

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        //private void Start()
        //{
        //    Connect();
        //}

        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Launcer: OnConnectedToMaster() was called by PUN");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogErrorFormat("PUN Basics Launcher: OnDisconnected() was called by PUN with reason: ", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Launcher: There was no room available, so we create new one.");

            //Nije bilo dostupne sobe, pa mi radimo vlasitu novu sobu
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Launcher: You joind the roooooom. Now clinet is in the rooooom");
        }

        /* Počni proces konekcije.
         * - Ako smo već konektirani onda napravi pokuaj ulaska u random sobu
         * - Ako nismo konektirani, poveži sa Photon Cloud Networkom
         */
        public void Connect()
        {
            if(PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }

            else
            {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }
    }
}