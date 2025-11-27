using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI Variables")]
    [SerializeField] private bool useAI;
    [SerializeField] float minimumFireRate = 0.2f;
    [SerializeField] float fireRateVariance = 0.0f;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;

    private void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            // Repeatedly fire projectiles
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (fireCoroutine != null && !isFiring)
        {
            // Stop firing projectiles
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.rotation = transform.rotation;

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = transform.up * projectileSpeed;

            Destroy(projectile, projectileLifetime);
            
            float waitTime =
                Random.Range(baseFireRate -fireRateVariance,baseFireRate+ fireRateVariance);
                
            waitTime = Mathf.Clamp(waitTime, minimumFireRate, float.MaxValue);
            yield return new WaitForSeconds(waitTime);
        }
    }
}