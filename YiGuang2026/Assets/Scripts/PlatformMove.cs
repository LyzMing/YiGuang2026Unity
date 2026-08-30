using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject pos1;
    [SerializeField] private GameObject pos2;

    private Vector2 movePos;

    // Start is called before the first frame update
    void Start()
    {
        movePos = pos2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, pos2.transform.position) < 0.1f)
        {
            movePos = pos1.transform.position;
        }
        else if (Vector2.Distance(transform.position, pos1.transform.position) < 0.1f)
        {
            movePos = pos2.transform.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, movePos, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
