using UnityEngine;
using Vector3 = UnityEngine.Vector3;
public class Turret : MonoBehaviour
{
    public GameObject projectileClone;
    public Vector3 spawnPos;
    private int maxProjectectiles;
    void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (maxProjectectiles < 5)
            {
                Instantiate(projectileClone, spawnPos, Quaternion.identity);
                Projectile cloneScript = projectileClone.GetComponent<Projectile>();
                maxProjectectiles += 1;
            }
            else
            {
                maxProjectectiles = 0;
            }
        }
    }
}