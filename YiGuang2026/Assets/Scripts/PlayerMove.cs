using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float distanceToGround;

    private Rigidbody2D rb;
    private float moveController;
    private Animator anim;
    private bool isRunScript;
    private bool isJumpScript;
    private bool isGroundScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveController = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
        if (moveController > 0)
            transform.localScale = new Vector2(1, 1);
        if (moveController < 0)
            transform.localScale = new Vector2(-1, 1);

        isGroundScript = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundLayer);
        if (Input.GetButtonDown("Jump") && isGroundScript)
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        if (rb.velocity.y > 0 && !isGroundScript)
            isJumpScript = true;
        else
            isJumpScript = false;

        anim.SetBool("isJump", isJumpScript);
        anim.SetBool("isGround", isGroundScript);

        isRunScript = (moveController != 0);
        anim.SetBool("isRun", isRunScript);
    }
}
