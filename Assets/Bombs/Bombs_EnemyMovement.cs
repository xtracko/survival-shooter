using UnityEngine;
using System.Collections;

public class Bombs_EnemyMovement : MonoBehaviour
{
    Transform player;
    Transform target;
    Bombs_PlayerHealth playerHealth;
    Bombs_EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<Bombs_PlayerHealth>();
        enemyHealth = GetComponent<Bombs_EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        TrackPlayer();
    }


    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(target.position);
        }
        else
        {
            nav.enabled = false;
        }
    }

    public void TrackPlayer()
    {
        target = player;
    }

    public void TrackDecoy(Transform decoy)
    {
        target = decoy;
    }
}
