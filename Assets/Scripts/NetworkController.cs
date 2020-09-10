using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] int gameVersion;

    // Start is called before the first frame update
    void Start()
    {
        // Gives us the Gameversion 
        PhotonNetwork.GameVersion = gameVersion.ToString();

        // Use photon settings created when we first started project
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to region " + PhotonNetwork.CloudRegion);
    }
}
