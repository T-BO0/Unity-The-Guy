using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    new BoxCollider2D collider;
    Rigidbody2D rb;
    SpriteRenderer srp;

    float dirX;
    [SerializeField] LayerMask theGround;
    [SerializeField] float moveSpeed = 7;
    [SerializeField] float jumpForce = 14f;

    enum AnimationState { standing, running, jumping, falling}
    [SerializeField]AudioSource jumpVoice;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        srp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && WeAreOnTheGround())
        {
            jumpVoice.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        AnimationSwitches();
    }


//acording to dirX animation will be changed<<
    void AnimationSwitches()
    {
        AnimationState animationState;

        if (dirX > 0f)
        {
            animationState = AnimationState.running;
            srp.flipX = false;
        }
        else if (dirX < 0f)
        {
            animationState = AnimationState.running;
            srp.flipX = true;
        }
        else
            animationState = AnimationState.standing;
        
        if(rb.velocity.y > .1f)
            animationState = AnimationState.jumping;
        else if(rb.velocity.y < -.1f)
            animationState = AnimationState.falling;

        anim.SetInteger("animationState", (int)animationState);
    }
    bool WeAreOnTheGround() => Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, theGround);



}
