using System;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    private Vector3 target;
    public PlayerController playerController;
    public int speed = 8;
    private Vector3 current;
    private double lifespan = 20;
    private Vector3 direction;
    
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        direction = ((target - transform.position).normalized) * speed;
    }

    void Update()
    {
        transform.position += (direction * Time.deltaTime);
        lifespan -= Time.deltaTime;
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}