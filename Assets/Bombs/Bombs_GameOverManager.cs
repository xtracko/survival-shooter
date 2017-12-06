using UnityEngine;

public class Bombs_GameOverManager : MonoBehaviour
{
    public Bombs_PlayerHealth playerHealth;


    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
