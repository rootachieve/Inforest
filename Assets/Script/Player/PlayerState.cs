using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public int str=5;
    public int maxHealth = 20;
    public int health=20;
    public bool isMove = false;
    public bool moveAble = true;
    public bool isJump = false;
    public bool isAttack = false;
    public bool isGameover = false;

    public float moveSpeed = 5f;
    public float jumpPower = 7f;
    private void Update()
    {
        if (!moveAble)
        {
            isMove = false;
            isJump = true;
        }
    }
}
