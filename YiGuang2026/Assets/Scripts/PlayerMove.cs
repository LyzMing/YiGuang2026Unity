using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpSpeed;

    private Rigidbody2D rb;
    private float moveController;
    private bool isRunScript;
    private bool isJumpScript;
    private Animator anim;

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

        if (Input.GetButtonDown("Jump"))
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        if (rb.velocity.y > 0.3f)
            isJumpScript = true;
        else
            isJumpScript = false;
        anim.SetBool("isJump", isJumpScript);

        isRunScript = (moveController != 0);
        anim.SetBool("isRun", isRunScript);
    }
}
