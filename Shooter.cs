using System;
using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;

    public bool isFiring;
    Coroutine fireCoroutine;

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
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocityY = projectileSpeed;
            Destroy(projectile, projectileLifetime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}