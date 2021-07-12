using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerState PS;//PlayerState
    public float cool;//cool time
    public GameObject hitPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !PS.isAttack && cool <= 0&&(!PS.isJump||PS.isRope)) //If you hit the attack key, cool time is below zero, and you're not already attacking.
        {
            cool = 60f; // cool time is 60(1 sec)
            
            PS.isAttack = true; //Attacking
            PS.isMove = false; 
        }
    }
    private void FixedUpdate()//Reduce cool time
    {
        if (cool > 0)
        {
            if (cool < 50)
            {
                hitPoint.SetActive(true); //GameObject hitPoint is Active
            }
            cool -= 1;//Reduce
            if (cool < 10)//End of Attack(motion)
            {
                PS.isAttack = false;
            }

            if (cool <= 0)
            {
                hitPoint.SetActive(false); // hitPoint is Unactive
            }
        }
    }
}
