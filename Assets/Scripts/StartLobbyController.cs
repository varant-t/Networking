using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class StartLobbyController : MonoBehaviourPunCallbacks
{
    // Informational UI
    [SerializeField] GameObject statusLabel;
    [SerializeField] GameObject btnStart;
    [SerializeField] GameObject btnCancel;

    // Room/Player Details
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] int roomSize;

    // Start is called before the first frame update
    void Start()
    {
        // Auto makes it so the button is not interactable 
        btnStart.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        statusLabel.GetComponent<TMP_Text>().text = "Connected to " + PhotonNetwork.CloudRegion;

        btnStart.SetActive(true);

        // Makes sures everyones to the same level
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Linked to Input Field
    public void SetPlayerName(TMP_InputField name)
    {
        btnStart.GetComponent<Button>().interactable = !string.IsNullOrEmpty(name.text);

        PhotonNetwork.NickName = name.text;
    }

    //Linked to Start Button
    public void StartGame()
    {
        btnStart.SetActive(false);
        btnCancel.SetActive(true);

        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinRoom("Room123");
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)roomSize
        };

        PhotonNetwork.CreateRoom("Room123", roomOptions);

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed... ");

        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)roomSize
        };


    }

    //Linked to Cancel Button
    public void CancelRoomJoin()
    {
        btnStart.SetActive(true);
        btnCancel.SetActive(false);

        PhotonNetwork.LeaveRoom();
    }
}
