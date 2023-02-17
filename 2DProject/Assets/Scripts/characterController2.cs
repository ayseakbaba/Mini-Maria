using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float speed = 1.0f;

    private bool isGrounded = true;
    private bool isJump;
    private bool isMove;
    private float moveDirection;

    private Rigidbody2D r2d;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (r2d.velocity != Vector2.zero)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
        r2d.velocity = new Vector2(speed * moveDirection, r2d.velocity.y);
        if (isJump == true)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
            isJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true && (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D))))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (isGrounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if (isGrounded == true && Input.GetKey(KeyCode.W))
        {
            isJump = true;
            isGrounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("isGrounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("isGrounded", true);
            isGrounded = true;
        }
    }
}
