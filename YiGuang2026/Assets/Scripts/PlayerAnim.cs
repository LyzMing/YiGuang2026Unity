using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private enum Anim { idle,run,jump,fall,hurt};
    [SerializeField] private Anim animState;
    private Animator anim;
    private PlayerMove playerMove;
    private PlayerDie playerDie;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerDie = GetComponent<PlayerDie>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimState();
    }

    private void SetAnimState()
    {
        if (playerDie.isDead)
            animState = Anim.hurt;
        else if (!playerMove.isRun && !playerMove.isJump && playerMove.isGround)
            animState = Anim.idle;
        else if (playerMove.isRun && playerMove.isGround)
            animState = Anim.run;
        else if (playerMove.isJump)
            animState = Anim.jump;
        else if (!playerMove.isJump && !playerMove.isGround)
            animState = Anim.fall;

        anim.SetInteger("state", (int)animState);
    }
}
