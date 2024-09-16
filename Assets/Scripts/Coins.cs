using UnityEngine;

[CreateAssetMenu(fileName = "Coins", menuName = "Scriptable Objects/Coins")]
public class Coins : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            gm.coins += 1;
            print(gm.coins);
        }
    }
}
