using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jump : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    public Vector3 boxSize;
    public float maxDistance;
    public GameObject terrain;

    public bool canJump = true;
    public float jumpValue = 0.0f;
    public PhysicsMaterial2D bounceMat, normalMat;

    public AutoJump auto;
    /*
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundMask = 1 << terrain.layer;
    }

    // Update is called once per frame
    void Update()
    {
       // moveInput = Input.GetAxisRaw("Horizontal");
        moveInput = auto.moveX;

        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
      
        }
       
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.4f), 0f, groundMask);

        if(jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else 
        {
            rb.sharedMaterial = normalMat;
        }
        
            if(Input.GetKey("space") && isGrounded && canJump) 
            {
                jumpValue += 0.1f;
            }
        
        if (auto.jump == 1 && isGrounded && canJump)
        {
            jumpValue += 0.1f;
        }
        
            if(Input.GetKeyDown("space") && isGrounded && canJump)
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }
        
        if (auto.jump == 0 && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
        
        if (jumpValue >= 20f && isGrounded)
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }
        
           if(Input.GetKeyUp("space"))
           {
               if(isGrounded)
               {
                   rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                   jumpValue = 0.0f;
               }

               canJump = true;
           }
        
        if (auto.jump == 0)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;
            }

            canJump = true;
        }
       
    }
     
    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundMask = 1 << terrain.layer;
    }

    // Update is called once per frame
    void Update()
    {
        // moveInput = Input.GetAxisRaw("Horizontal");
        moveInput = auto.moveX;

        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);

        }

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.4f), 0f, groundMask);

        if (jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }
        /*
            if(Input.GetKey("space") && isGrounded && canJump) 
            {
                jumpValue += 0.1f;
            }
        */
        /*
        if (auto.jump == 1 && isGrounded && canJump)
        {
            jumpValue = 5f;
        }

        if (auto.jump == 2 && isGrounded && canJump)
        {
            jumpValue = 10f;
        }

        if (auto.jump == 3 && isGrounded && canJump)
        {
            jumpValue = 15f;
        }

        if (auto.jump == 4 && isGrounded && canJump)
        {
            jumpValue = 20f;
        }
        */

        if(auto.jump >0 && isGrounded && canJump) 
        {
            jumpValue = (float)auto.jump;
        }

        /*
            if(Input.GetKeyDown("space") && isGrounded && canJump)
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }
        */
        if (auto.jump != 0 && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (jumpValue >= 20f && isGrounded)
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }
        /*
           if(Input.GetKeyUp("space"))
           {
               if(isGrounded)
               {
                   rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                   jumpValue = 0.0f;
               }

               canJump = true;
           }
        */
        if (auto.jump == 0)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;
            }

            canJump = true;
        }

    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));
    }





}