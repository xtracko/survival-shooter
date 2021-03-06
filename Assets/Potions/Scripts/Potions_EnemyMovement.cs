﻿using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class Potions_EnemyMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        Potions_PlayerHealth playerHealth;      // Reference to the player's health.
        Potions_EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <Potions_PlayerHealth> ();
            enemyHealth = GetComponent <Potions_EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        }


        void Update ()
        {
            // If the enemy and the player have health left...
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination (player.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}