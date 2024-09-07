
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Body;
    private Animator anim;
    public float speed;
    private bool grounded;
  

    private void Awake()
    { 
      
        Body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    

    private void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,Body.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one; 
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.Space) && grounded )
        {
            Jump();
         
        }
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

private void Jump()
    {
        Body.velocity = new Vector2(Body.velocity.x, speed);
            anim.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground");
        grounded = true;
    }




}
