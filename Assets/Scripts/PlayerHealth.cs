using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    int health;
    [SerializeField] TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.text = health.ToString();
    }

    public void takeDamage(int damage)
    {
        health += damage;

        healthText.text = health.ToString();

        if(health <= 0)
        {
            Debug.Log("Bye Bye");

            //Remove Player From Room
            //Respawn Player/Enemy
            //Destroy Enemy

        }
    }

    public int getHealth()
    {
        return health;
    }


}

 
