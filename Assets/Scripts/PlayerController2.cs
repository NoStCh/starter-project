using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Collider2D PlayerCollider;
    public float length;
    private Rigidbody2D rb;
    private float JumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
        length = 0.9f;
        JumpForce = 350f;
    }

    void Update()
    {
        RaycastHit2D leftRay = Physics2D.Raycast(new Vector2(transform.position.x - PlayerCollider.bounds.center.x, transform.position.y), Vector2.down, length);
        Debug.DrawRay(new Vector2(transform.position.x - PlayerCollider.bounds.center.x, transform.position.y), Vector2.down * length, Color.red);
        RaycastHit2D rightRay = Physics2D.Raycast(new Vector2(transform.position.x + PlayerCollider.bounds.center.x, transform.position.y), Vector2.down, length);
        Debug.DrawRay(new Vector2(transform.position.x + PlayerCollider.bounds.center.x, transform.position.y), Vector2.down * length, Color.red);

        if ((leftRay.collider != null || rightRay.collider != null) && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * JumpForce);
        }
    }
}
