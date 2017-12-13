using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class Bombs_PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.


    float timer;                                    // A timer to determine when to fire.
    Ray shootRay = new Ray();                       // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    ParticleSystem gunParticles;                    // Reference to the particle system.
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    public Light faceLight;                             // Duh
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");

        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        //faceLight = GetComponentInChildren<Light> ();
    }


    void Update()
    {
        timer += Time.deltaTime;

#if !MOBILE_INPUT
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }
#else
            // If there is input on the shoot direction stick and it's time to fire...
            if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            {
                // ... shoot the gun
                Shoot();
            }
#endif
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;
        faceLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            Bombs_EnemyHealth enemyHealth = shootHit.collider.GetComponent<Bombs_EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }

            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}