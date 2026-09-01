using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject pos1;
    [SerializeField] private GameObject pos2;

    private Vector2 movePos;
    private Rigidbody2D rb;

    public Vector2 CurrentVelocity { get; private set; }   // 新增：当前平台速度

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = pos1.transform.position;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(rb.position, pos2.transform.position) < 0.1f)
            movePos = pos1.transform.position;
        else if (Vector2.Distance(rb.position, pos1.transform.position) < 0.1f)
            movePos = pos2.transform.position;

        Vector2 newPos = Vector2.MoveTowards(rb.position, movePos, moveSpeed * Time.fixedDeltaTime);
        CurrentVelocity = (newPos - rb.position) / Time.fixedDeltaTime;   // 新增：记录速度
        rb.MovePosition(newPos);
    }
}