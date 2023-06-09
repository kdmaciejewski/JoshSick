using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;
    private Animator anim;
    private SpriteRenderer sprite;
    float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    
    private enum MovementsState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {   
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimation();
    }

    private void UpdateAnimation(){
        
        MovementsState state;

        if(dirX > 0f){
            state = MovementsState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f){
            state = MovementsState.running;
            sprite.flipX = true;
        }
        else{
            state = MovementsState.idle;
        }

        if (rb.velocity.y > .1f){
            state = MovementsState.jumping;
        }
        else if ( rb.velocity.y < -.1f){    //spadamy
            state = MovementsState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded(){
        //tworzymy boxa wokół naszego playera który ma taki sam obszar jak  kiedyś ustwiliśmy
        // i potem przesuwamy go trochę niżej, żeby wykrywało że jesteśmy na ziemii, jumpable to maska podłogi
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
