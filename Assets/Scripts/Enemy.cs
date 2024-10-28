using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private Vector3 current;
    private Vector3 direction;
    GameManager GM;
    PlayerController playerController;
    private float distance;
    public float state;
    private float changetime;
    private Animator animator;
    private AnimatorStateInfo stateInfo;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        GM = FindFirstObjectByType<GameManager>();
        animator = FindFirstObjectByType<Animator>();
        changetime = 300;
        current = transform.position;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
    }

    void Update()
    {
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
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            
            if (stateInfo.IsName("Attack") && stateInfo.normalizedTime < 1.0f)
            {
               
                GM.health -= 1;
            }

            direction = ((target - transform.position).normalized * 3);
            transform.position += (direction * Time.deltaTime) / 2;
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
    }
}
