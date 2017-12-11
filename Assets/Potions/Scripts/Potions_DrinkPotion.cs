using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class Potions_DrinkPotion : MonoBehaviour
    {

        GameObject player;
        Potions_PlayerHealth playerHealth;
        

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<Potions_PlayerHealth>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                playerHealth.Heal();
                Destroy(gameObject);
            }
            
        }
    }
}
