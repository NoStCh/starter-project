using UnityEngine;
public class PlayerController : MonoBehaviour
{
    float xdirection;
    float xspeed;
    public float xvector;
    float ydirection;
    float yspeed;
    public float yvector;
    public float playerX;
    public float playerY;
    public bool overworld; 
    private Collider2D PlayerCollider;
    public float length;
    private Rigidbody2D rb;
    private float JumpForce;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
        length = 0.9f;
        JumpForce = 350f;
        
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
        RaycastHit2D leftRay = Physics2D.Raycast(new Vector2(transform.position.x - PlayerCollider.bounds.center.x, transform.position.y), Vector2.down, length);
        Debug.DrawRay(new Vector2(transform.position.x - PlayerCollider.bounds.center.x, transform.position.y), Vector2.down * length, Color.red);
        RaycastHit2D rightRay = Physics2D.Raycast(new Vector2(transform.position.x + PlayerCollider.bounds.center.x, transform.position.y), Vector2.down, length);
        Debug.DrawRay(new Vector2(transform.position.x + PlayerCollider.bounds.center.x, transform.position.y), Vector2.down * length, Color.red);
        
        print(leftRay);
        
        if ((leftRay.collider != null || rightRay.collider != null) && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * JumpForce);
        }
        
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