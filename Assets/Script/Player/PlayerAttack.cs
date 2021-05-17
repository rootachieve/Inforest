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
        if (Input.GetKeyDown(KeyCode.X) && !PS.isAttack && cool <= 0) //If you hit the attack key, cool time is below zero, and you're not already attacking.
        {
            cool = 60f; // cool time is 60(1 sec)
            hitPoint.SetActive(true); //GameObject hitPoint is Active
            PS.isAttack = true; //Attacking
        }
    }
    private void FixedUpdate()//Reduce cool time
    {
        if (cool > 0)
        {
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
