using System;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 target;
    public int speed;
    private PlayerController playerController;
    private Vector3 current;
    private Vector3 direction;
    
    void Start()
    {
        speed = 5;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        direction = (target - transform.position).normalized;
    }

    void Update()
    {
        Vector3 current = transform.position;
        Vector3 newposition = Vector3.MoveTowards(current, target, speed * Time.deltaTime);
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}