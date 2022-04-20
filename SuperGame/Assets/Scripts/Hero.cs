using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Flick();
        Jump();
        Dash(); 
        CheckingGround();
    }

    public Vector2 moveVector;
    public float speed;

    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    }

    public bool flic = true;
    void Flick()
    {
        if ((moveVector.x > 0 && flic) || (moveVector.x < 0 && !flic))
        {
            transform.localScale *= new Vector2(-1, 1);
            flic = !flic;
        }
    }

    public int DashImpulse ;
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.F) && Input.GetButton("Horizontal"))
        {
            rb.velocity = new Vector2(0, 0);
            if (flic) { rb.AddForce(Vector2.left * DashImpulse); }
            else {rb.AddForce(Vector2.right * DashImpulse); }
        }
        

    }

    public float jumpForce;
    private int maxJump = 2;
    private int numJump = 0;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            Invoke("IgnoreOff",1f);
        }

        if (onGround && Input.GetKeyDown(KeyCode.Space) )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numJump++;
            anim.SetInteger("numJump",numJump);
        }
        else if (!onGround && numJump < maxJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numJump++;
            anim.SetInteger("numJump", numJump);
        }
        else if (onGround && numJump == maxJump) 
        { 
            numJump = 0;
            anim.SetInteger("numJump", numJump);
        }
    }

    void IgnoreOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
        anim.SetBool("onGround", onGround );
    }
}