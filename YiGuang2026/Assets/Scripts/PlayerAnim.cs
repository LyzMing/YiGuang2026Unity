using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private enum Anim { idle,run,jump,fall};
    private Anim animState;
    private Animator anim;
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimState();
    }

    private void SetAnimState()
    {
        if (!playerMove.isRun && !playerMove.isJump && playerMove.isGround)
            animState = Anim.idle;
        else if (playerMove.isRun && playerMove.isGround)
            animState = Anim.run;
        else if (playerMove.isJump)
            animState = Anim.jump;
        else
            animState = Anim.fall;

        anim.SetInteger("state", (int)animState);
    }
}
