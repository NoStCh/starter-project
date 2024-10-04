using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; // Speed of the projectile
    public float lifeTime = 10f; // Time before the projectile is destroyed

    private Transform target; // Target to follow (the player)
    private float timer;

    void Start()
    {
        // Find the player GameObject by tag or name
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        // Optional: Destroy the projectile after a certain time
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate direction to the target
            Vector2 direction = (target.position - transform.position).normalized;

            // Move the projectile in that direction
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Add logic for when the projectile hits something (e.g., the player)
        if (collision.CompareTag("Player"))
        {
            // Handle collision (e.g., damage the player)
            Destroy(gameObject); // Destroy the projectile on impact
        }
    }
}