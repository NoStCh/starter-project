using UnityEngine;
public class Coins : MonoBehaviour
{
    GameManager Gm;

    private void Start()
    {
        Gm = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Gm.coins += 1;
            print(Gm.coins);
        }
    }
}
