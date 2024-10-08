using UnityEngine;
public class Turret : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject projectilePrefab;
    
    private void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
            Projectile Script = projectilePrefab.GetComponent<Projectile>();
        }
    }
}