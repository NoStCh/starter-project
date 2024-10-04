using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    public Transform firePoint; // Point from where projectiles will spawn
    public float fireRate = 15f; // Rate of fire (projectiles per second)

    public float nextFireTime;

    void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate; // Set next fire time
        }
    }

    void Fire()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        // Optionally set the velocity or direction of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * 10f; // Adjust the speed as needed
        }
    }
}
