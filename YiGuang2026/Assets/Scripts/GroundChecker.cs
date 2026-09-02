using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGround;

    private Coroutine coyoteCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
            if (coyoteCoroutine != null)
            {
                StopCoroutine(coyoteCoroutine);
                coyoteCoroutine = null;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (isActiveAndEnabled)
                coyoteCoroutine = StartCoroutine(CoyoteTime());
        }
    }

    //优化跳跃手感的土狼时间
    private IEnumerator CoyoteTime()
    {
        yield return new WaitForSeconds(0.1f);
        isGround = false;
        coyoteCoroutine = null;
    }
}
