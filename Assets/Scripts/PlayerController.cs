using UnityEngine;
public class PlayerController : MonoBehaviour
{
    float xdirection;
    float xspeed;
    float xvector;
    float ydirection;
    float yspeed;
    float yvector;
    public float playerX;
    public float playerY;
    public bool overworld; 
    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?

        xdirection = 0;
        xspeed = 4;
        xvector = 0;
        ydirection = 0;
        yspeed = 4;
        yvector = 0;

        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void Update()
    {
        playerX = transform.position.x;
        playerY = transform.position.y;
        
        xdirection = Input.GetAxis("Horizontal");
        xvector = xdirection * xspeed * Time.deltaTime;
        transform.Translate(xvector, 0, 0);
        ydirection = Input.GetAxis("Vertical");
        yvector = ydirection * yspeed * Time.deltaTime;
        transform.Translate(0,yvector, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            print("Wall");
        }
    }
}