
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator animator;

    public float speed;   // speed at which player will move
    public float jumpSpeed;    // force on player jump
    public bool isGrounded;  // to check wheteher player is on ground or not
    public float feetRadius;
    public Transform feet;  // to get feet gameobject from the inspector
    public float boxWidth;
    public float boxHeight;
    public LayerMask whatIsGround;  // to check the layer

    

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth, boxHeight), 360.0f, whatIsGround);

        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        moveCharacter(horizontal);

        crouch();
       
        playMovementAnimation(horizontal);

        if (Input.GetButtonDown("Jumps") && isGrounded)
        {
            Jump();
            
        }
    }


    private void OnDrawGizmos() // draws gizmos foe debugging
    {
        Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight, 0));
    }


    void moveCharacter(float horizontal)   // function to move player 
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void playMovementAnimation(float horizontal)
    {
       
        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

       
       animator.SetFloat("Speed", Mathf.Abs(horizontal));

    }


    void Jump()  // jump function
    {
        if (isGrounded)
        {
            animator.SetTrigger("jump");
            //animator.SetBool("Jump", true);
           rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }


    void crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.53f, 1.29f);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.02f, 0.59f);

            animator.SetBool("Crouch", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.53f, 2.01f);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.02f, 0.95f);

            animator.SetBool("Crouch", false);
        }
    }
}


     

