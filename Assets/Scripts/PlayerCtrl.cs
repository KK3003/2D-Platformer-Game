using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator animator;


    private Vector2 scale; 

    // Start is called before the first frame update
    void Start()
    {
        scale = gameObject.GetComponent<Collider2D>().transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));

        Vector2 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);    
        } else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        float jump1 = Input.GetAxisRaw("Vertical");
        if(jump1 > 0)
        {
            animator.SetBool("jump", true);
        }else if(jump1 < 0)
        {
            animator.SetBool("jump", false);
        }


    }


    private void FixedUpdate()
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
