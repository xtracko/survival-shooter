using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bombs_ExplosiveBomb : MonoBehaviour
{
    public float idleTime = 1f;
    public float radius = 5f;
    public int damage = 200;
    public int threshold = 4;

    public Material idleMaterial;
    public Material activeMaterial;

    bool isActive = false;

    void Awake()
    {
        GetComponent<Projector>().orthographicSize = radius;
        GetComponent<Projector>().material = idleMaterial;
        Invoke("Activate", idleTime);
    }

    void Activate()
    {
        isActive = true;
        GetComponent<Projector>().material = activeMaterial;
    }

    void Update()
    {
        if (!isActive)
            return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        int count = colliders.Count(c => c.GetComponent<Bombs_EnemyHealth>() != null);

        if (count >= threshold)
        {
            Explode();
        }
    }

    void Explode()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, radius))
        {
            Bombs_EnemyHealth enemyHealth = collider.GetComponent<Bombs_EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDemage(damage);
            }

            CompleteProject.PlayerHealth playerHealth = collider.GetComponent<CompleteProject.PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
