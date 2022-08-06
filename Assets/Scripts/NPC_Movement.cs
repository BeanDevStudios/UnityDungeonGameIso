using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour {

    public bool isWalking;
    public float moveSpeed;
    public float walkTime;
    public float waitTime;
    private float waitCounter;
    private float walkCounter;
    private int walkDirection;
    private bool hasWalkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    public Vector2 facing;
    public Animator anim;
    private Rigidbody2D rb;
    public Collider2D walkZone;
 
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();

        if(walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }
 
    void Update ()
    {
        if(isWalking == false)
        {
            facing.x = 0;
            facing.y = 0;
        }

        if(isWalking == true)
        {
            walkCounter -= Time.deltaTime;
           
            switch (walkDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, moveSpeed);
                    facing.y = 1;
                    facing.x = 0;
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    facing.x = 1;
                    facing.y = 0;
                    if(hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                    break;

                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    facing.y = -1;
                    facing.x = 0;
                    if(hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    facing.y = 0;
                    facing.x = -1;
                    if(hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    transform.localScale = new Vector3(-0.6f, 0.6f, 1f);
                    break;          
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }

        else
        {
            rb.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
        anim.SetBool("isWalking", isWalking);
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}