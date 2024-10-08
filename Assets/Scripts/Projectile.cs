using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 target;
    public int speed;
    private PlayerController playerController;
    private Vector3 current;
    private void Start()
    {
        speed = 1;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
    }

    private void Update()
    {
        Vector3 current = transform.position;

        Vector3 newposition = Vector3.MoveTowards(current, target, speed * Time.deltaTime);
        transform.position = newposition;
    }
}