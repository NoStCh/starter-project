using UnityEngine;

[CreateAssetMenu(fileName = "Coins", menuName = "Scriptable Objects/Coins")]
public class Coins : MonoBehaviour
{
    GameManager Gm;

    private void Start()
    {
        Gm = FindAnyObjectByType<GameManager>();

    }

    private void Update()
    {
        void OnTriggerEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Gm.coins += 1;
                Destroy(other.gameObject);
                print(Gm.coins);
            }
        }
    }
}
