using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private Vector3 current;
    private Vector3 direction;
    GameManager Gm;
    Door D;
    PlayerController playerController;
    private float distance;
    public float state;
    private float changetime;
    private float Tim;
    private float Tim1;
    public bool Plat;

    public float Vel;
    public float length;
    Collider2D collider2d;

    void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = !Plat;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = Plat;
        if (!Plat)
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
        else
        {
            Vel = 0;
            collider2d = GetComponent<Collider2D>();
        }
    }

    void Update()
    {
        if (!Plat)
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
        else
        {
            Vel += Random.Range(-100, 100) / 100;
            transform.Translate(Vel, 0, 0);
            
            Vector2 leftRayOrigin = new Vector2(transform.position.x - collider2d.bounds.extents.x, transform.position.y);
            Vector2 rightRayOrigin = new Vector2(transform.position.x + collider2d.bounds.extents.x, transform.position.y);

            // Perform the raycasts downward
            RaycastHit2D leftRay = Physics2D.Raycast(leftRayOrigin, Vector2.left, length);
            RaycastHit2D rightRay = Physics2D.Raycast(rightRayOrigin, Vector2.right, length);

            // Draw the rays for debugging (only draw in Scene view, not in game)
            Debug.DrawRay(leftRayOrigin, Vector2.down * length, Color.red);
            Debug.DrawRay(rightRayOrigin, Vector2.down * length, Color.red);

            // Check if either ray hits a collider (indicating ground)
            if (leftRay.collider != null || rightRay.collider != null)
            {
                print("balls");
            }
        }
    }
}
