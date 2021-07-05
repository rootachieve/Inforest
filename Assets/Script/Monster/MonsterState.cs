using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState : MonoBehaviour
{
    public int health;
    public int str;

    public bool moveAble = true;
    public bool death = false;
    public bool isAttack=false;
    public bool isMove = false;
    public float moveSpeed;
    public float jumpPower;
    public GameObject particle;

    public int Count;
    private void FixedUpdate()
    {
        if (death)
        {
            Count++;
            moveAble = false;
            particle.SetActive(true);
            if (Count > 30)
            {
                gameObject.SetActive(false);
            }

        }   
    }

}
