
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Body;
    public float speed;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private Animator anim;
    private BoxCollider2D boxcollider;
    



    private void Awake()
    {
        // refernece  to rigidbody and animator from object
        Body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();

    }


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Body.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();

        }

        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        print(onWall());

    }

    private void Jump()
    {
        Body.velocity = new Vector2(Body.velocity.x, speed);
        anim.SetTrigger("jump");
      
    }

  

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }


}
