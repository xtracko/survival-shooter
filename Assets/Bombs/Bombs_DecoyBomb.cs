using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs_DecoyBomb : MonoBehaviour
{
    public float activeTime = 5f;
    public float radius = 5f;

    void Awake()
    {
        GetComponent<Projector>().orthographicSize = radius;

        Invoke("Deactivate", activeTime);
    }

    void Deactivate()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, radius)) {
            Bombs_EnemyMovement enemyMovement = collider.GetComponent<Bombs_EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.TrackPlayer();
            }
        }

        Destroy(gameObject);
    }

    void Update()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, radius))
        {
            Bombs_EnemyMovement enemyMovement = collider.GetComponent<Bombs_EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.TrackDecoy(transform);
            }
        }
    }
}
