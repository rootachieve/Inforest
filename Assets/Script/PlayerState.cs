using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool isMove = false;
    public bool moveAble = true;
    public bool isJump = false;

    public float moveSpeed = 5f;
    public float jumpPower = 7f;
    private void Update()
    {
        if (!moveAble)
        {
            isMove = false;
            isJump = false;
        }
    }
}
