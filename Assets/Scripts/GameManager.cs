using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    GameObject[] enemySpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoints");
        CreatePlayer();
        CreateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayer()
    {
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", playerPrefab.name), Vector3.zero, Quaternion.identity);

        player.name = PhotonNetwork.NickName;
    }

    void CreateEnemies()
    {
        Debug.Log("Creating: " + enemySpawnPoints + " enemies");
    }
}
