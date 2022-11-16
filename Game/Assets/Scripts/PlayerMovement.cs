using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D body;
    private float moveInput;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private void Awake()
    {
        extraJumps = extraJumpsValue;
        body = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(moveInput * speed, body.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        //flip player when moving left or right
        //if (moveInput > 0.01f)
        //    transform.localScale = Vector3.one;
        //else if (moveInput < -0.01f)
        //    transform.localScale = new Vector3(-1, 1, 1);

        //if (Input.GetKey(KeyCode.W) && grounded)
        //    Jump();
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0); 
    }



    private void Update()
    {
        //body.velocity = new Vector2(body.velocity.x, speed);
        //grounded = false;

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){

            body.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            body.velocity = Vector2.up * jumpForce;
        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //        grounded = true;
    //}
}
