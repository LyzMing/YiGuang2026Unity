using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isRun;
    public bool isJump;
    public bool isGround;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float distanceToGround;
    [SerializeField] private float force;

    private Rigidbody2D rb;
    private float moveController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    private void FixedUpdate()
    {
        if (isJump)
            rb.AddForce(Vector2.down * force);
    }

    private void Run()
    {
        moveController = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
        if (moveController > 0)
            transform.localScale = new Vector2(1, 1);
        if (moveController < 0)
            transform.localScale = new Vector2(-1, 1);
        isRun = (moveController != 0);
    }

    private void Jump()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundLayer);

        if (Input.GetButtonDown("Jump") && isGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        if (rb.velocity.y > 0 && !isGround)
            isJump = true;
        else
            isJump = false;
    }
}
