using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Animator animator;
    public int str=5;
    public int maxHealth = 20;
    public int health=20;
    public bool isMove = false;
    public bool moveAble = true;
    public bool isJump = false;
    public bool isAttack = false;
    public bool isRope = false;
    public bool isGameover = false;
    public bool isDamage = false;
    public float moveSpeed = 3.5f;
    public float jumpPower = 7f;
    private void Update()
    {
        if (!moveAble)//If you can't move, change isjump to true, prevent jumping, and eliminate movement.
        {
            isMove = false;
            isJump = true;
        }


        //Below animation control
        if (isMove)
            animator.SetBool("isWalk", true);
        else
            animator.SetBool("isWalk", false);

        if (isJump)
            animator.SetBool("isJump", true);
        else
            animator.SetBool("isJump", false);

        if (isAttack)
            animator.SetBool("isAttack", true);
        else
            animator.SetBool("isAttack", false);

        if (isRope)
            animator.SetBool("isRope", true);
        else
            animator.SetBool("isRope", false);

        if (isGameover)
            animator.SetBool("isGameover", true);
        else
            animator.SetBool("isGameover", false);

        if (moveAble)
            animator.SetBool("Moveable", true);
        else
            animator.SetBool("Moveable", false);

        if (isDamage)
            animator.SetBool("isDamage", true);
        else
            animator.SetBool("isDamage", false);

    }
}
