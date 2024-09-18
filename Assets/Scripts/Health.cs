using UnityEngine;

public class Health : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }

    private void Update()
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Health"))
            {
                gm.coins += 1;
                print(gm.coins);
            }
        }
    }
}