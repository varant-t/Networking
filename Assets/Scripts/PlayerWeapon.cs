using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerWeapon : MonoBehaviourPun
{
    [SerializeField] float projectileSpeed = 5.0f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(photonView.IsMine)
        {
            TakeInput();
        }
    }

    void TakeInput()
    {
        if(!Input.GetButtonDown("Fire1"))
        {
            return;
        }
        // Local Call
        //fire();

        // RPC Call: Left all clients know a projectile(raycast) was fired
        photonView.RPC("fire", RpcTarget.All);
    }

    [PunRPC]
    void fire()
    {
        RaycastHit hit;

        Debug.DrawRay(projectileSpawnPoint.position, projectileSpawnPoint.forward * 10, Color.red);
        if(Physics.Raycast(projectileSpawnPoint.position, projectileSpawnPoint.forward, out hit, 10))
        {
            Debug.Log("Hit: " + hit.collider.name);

            PlayerHealth ph = hit.collider.GetComponent<PlayerHealth>();

            if (ph)
            {
                ph.takeDamage(-10);
            }
        }

        // Instantiate the projectile 
       // GameObject projectile = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", projectilePrefab.name), projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        //projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileSpeed;
    }

}
