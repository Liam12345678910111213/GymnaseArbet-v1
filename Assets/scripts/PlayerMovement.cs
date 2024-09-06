
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Body;
    public float speed;
    
    public bool isJumping;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }
    

    private void Update ()
    {
        Body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,Body.velocity.y);




        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            Body.velocity = new Vector2(Body.velocity.x, speed);
         
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }





}
