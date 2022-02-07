using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{

    public Transform leftBound, rightBound;
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sr; // helps in turning enemy
    public float maxDelay, minDelay; // time before turning back

    bool canTurn;
    float originalSpeed; // help in turning the enemy
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        SetStartingDirection();
        canTurn = true;
    }

    private void Update()
    {
        Move();
        FlipOnEdges();
    }


    void SetStartingDirection()
    {
        if(speed > 0)
        {
            sr.flipX = true;
        } 
        else if(speed < 0)
        {
            sr.flipX = false;
        }
    }
    void Move()
    {
        Vector2 temp = rb.velocity;
        temp.x = speed;
        rb.velocity = temp;
    }


    void FlipOnEdges()
    {
        if (sr.flipX && transform.position.x >= rightBound.position.x)
        {

            if (canTurn)
            {
                canTurn = false;
                originalSpeed = speed;
                speed = 0;
                StartCoroutine("TurnLeft", originalSpeed);
            }

        }
        else if (!sr.flipX && transform.position.x <= leftBound.position.x)
        {
            if (canTurn)
            {
                canTurn = false;
                originalSpeed = speed;
                speed = 0;
                StartCoroutine("TurnRight", originalSpeed);
            }
        }
    }


    IEnumerator TurnLeft(float originalSpeed)
    {
        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        anim.SetBool("isIdle", false);
        sr.flipX = false;
        speed = -originalSpeed;
        canTurn = true;
    }

    IEnumerator TurnRight(float originalSpeed)
    {
        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        anim.SetBool("isIdle", false);
        sr.flipX = true;
        speed = -originalSpeed;
        canTurn = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(leftBound.position, rightBound.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCtrl>() != null)
        {
            PlayerCtrl playerctrl = collision.gameObject.GetComponent<PlayerCtrl>();
            playerctrl.killPlayer();
            
        }
    }
}
