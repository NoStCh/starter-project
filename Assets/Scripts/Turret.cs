using UnityEngine;
public class Turret : MonoBehaviour
{
    private float firerate;
    private double cooldown;
    private GameObject player;
    public GameObject projectileClone;
    public Vector3 spawnPos;
    void Start()
    {
        player = null;
        firerate = 1;
        cooldown = 5;
        spawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0 && player != null)
        {
            PlayerController pc = player.GetComponent<PlayerController>();
            Instantiate(projectileClone, spawnPos, Quaternion.identity);
            Projectile clonescript = projectileClone.GetComponent<Projectile>();
            clonescript.playerController = pc;
            cooldown = firerate;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }
}