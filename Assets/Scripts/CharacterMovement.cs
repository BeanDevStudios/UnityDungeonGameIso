using System.Xml.Schema;
using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DialogueEditor;

public class CharacterMovement : MonoBehaviour
{
    //Variables
    public Tilemap map;//Reference to our map
    MouseInput mouseInput;//Reverence to our mouse input object
    private Vector3 destination;//Location we want the character to move to
    private float moveSpeed;
    public bool facingRight = true;
    private Vector2 mousePosition;

    public Animator animator;
    public Vector2 facing;
    private Rigidbody2D rb;
    public float player;
    public NPCConversation conv;

    private void Awake()
    {
        mouseInput = new MouseInput();
    }

    //Enable script 
    private void OnEnable()
    {
        mouseInput.Enable();
    }

    //Disable script
    private void OnDisable()
    {
        mouseInput.Disable();
       
    }
    // Start is called before the first frame update
    void Start()
    {
         
        rb = GetComponent<Rigidbody2D>();

        ConversationManager.Instance.StartConversation(conv);
        
        destination = transform.position;
        mouseInput.mouse.MouseClick.performed += _ => MouseClick();
    }

    //Gets position of mouse
    private void MouseClick()
    {
        mousePosition = mouseInput.mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Checking if a cell was clicked
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if(map.HasTile(gridPosition)){
            destination = mousePosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
            if(mousePosition.x < transform.position.x && facingRight)
            {
                Flip();
            }
            else if(mousePosition.x > transform.position.x && !facingRight)
            {
                Flip();
            }
            
        if(Vector3.Distance(transform.position, destination) > 0.1f){
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            moveSpeed=2f;

        }
        else{
            moveSpeed=0f;
        }

        animator.SetFloat("Speed", moveSpeed);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
