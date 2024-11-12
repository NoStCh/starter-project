using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private Vector3 current;
    private Vector3 direction;
    GameManager Gm;
    PlayerController playerController;
    private float distance;
    public float state;
    private float changetime;
    private float Tim;
    private float Tim1;
    Door D;
    /**public GameObject AxeItem;
    private Vector3 SpawnPos;**/
    

    void Start()
    {
        D.hasaxe = false;
        playerController = FindFirstObjectByType<PlayerController>();
        Gm = FindFirstObjectByType<GameManager>();
        D = FindFirstObjectByType<Door>();
        changetime = 300;
        current = transform.position;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        Tim = 500f;
        Tim1 = 500f;
    }

    void Update()
    {
        Tim -= 0.5f;
        Tim1 -= 1f; 
        distance = Vector3.Distance(gameObject.transform.position, target);
        if (distance < 4.5)
        {
            if (distance < 1.25)
            {
                state = 3;
            }
            else
            {
                state = 2;
            }
        }
        else
        {
            state = 1;
        }

        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        if (state == 2)
        {
            direction = ((target - transform.position).normalized) * 3;
            transform.position += (direction * Time.deltaTime);
        }

        if (state == 3)
        {
            if (Tim <= 0f)
            {
                Gm.health -= 1;
                Tim = 500f;
            }

            direction = ((target - transform.position).normalized * 3);
            transform.position += (direction * Time.deltaTime) / 2;
        }
        
        if (Input.GetMouseButton(0) && Tim1 <= 0f)
        {
            Gm.Mealth -= 1;
            Tim1 = 500f;
        }

        current = transform.position;
        if (state == 1)
        {
            changetime -= 1;
            if (changetime < 1)
            {
                direction = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
                changetime = Random.Range(750, 4000);
            }

            transform.position += ((direction * Time.deltaTime) * 0.06f);
        }
        
        /**SpawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);**/
        
       if (Gm.Mealth < 1)
       {
            D.hasaxe = true;
            /**Instantiate(AxeItem, SpawnPos, Quaternion.identity);**/
            Destroy(gameObject);
        }
    }
}
