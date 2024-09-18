using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "Scriptable Objects/GameManager")]
public class GameManager : MonoBehaviour
{
    public static GameManager Gm;

    public int coins;
    public int health;
    private void Awake()
    {
        if (Gm != null && Gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

