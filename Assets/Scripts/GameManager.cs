using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI healthText;
    
    public static GameManager Gm;
    
    public int coins;
    public int health;
    private void Awake()
    {
        health = 100;
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
    private void Start()
    {
        coinsText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;

    }
    private void Update()
    {
        coinsText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;

        if (health < 1)
        {
            SceneManager.LoadScene("Start");
        }
    }
}