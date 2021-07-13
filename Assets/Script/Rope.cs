using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Animator animator;//animation
    public bool inPlayer = false;
    public PlayerState PS;
    public Rigidbody2D PR;
    PlayerHit PH;
    public GameObject PL;
    // Update is called once per frame

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && inPlayer)//If the player is on the rope and you press the c key
        {
            PS.moveAble = false;
            PS.isRope = true;
            PR.gravityScale = 0;
            PL.transform.position = new Vector3(transform.position.x, PL.transform.position.y, PL.transform.position.z);
            PR.velocity = new Vector2(0, 0);
            //Secure the player to the rope.
        }

        //(Under)I'm adjusting the movement on the rope for animation.
        if (Input.GetKey(KeyCode.UpArrow) && PS.isRope&&!PS.isAttack)//Going up.
        {
            PL.transform.position = new Vector3(PL.transform.position.x, PL.transform.position.y + 2*Time.deltaTime, PL.transform.position.z);
            if (!Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.SetInteger("RopeMove", 1);
            }
            else
            {
                animator.SetInteger("RopeMove", 0);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && PS.isRope && !PS.isAttack)//Step down.
        {
            PL.transform.position = new Vector3(PL.transform.position.x, PL.transform.position.y - 2*Time.deltaTime, PL.transform.position.z);
            if (!Input.GetKeyUp(KeyCode.UpArrow))
            {
                animator.SetInteger("RopeMove", -1);
            }
            else
            {
                animator.SetInteger("RopeMove", 0);
            }
        }
        else
        {
            animator.SetInteger("RopeMove", 0);
        }
        //(Upper)I'm adjusting the movement on the rope for animation.

        if (PS.isRope&&PS.isDamage)//You'll fall if you're attacked.
        {
            PS.moveAble = false;
            PS.isRope = false;
            PR.gravityScale = 1;
        }
        

        if (PS.isRope&&Input.GetKeyDown(KeyCode.Z))//Press z to escape and jump.
        {
            PS.moveAble = true;
            PS.isRope = false;
            PR.gravityScale = 1;
            PR.AddForce(new Vector2(0, 7f), ForceMode2D.Impulse);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            PR = collision.gameObject.GetComponent<Rigidbody2D>();
            PH = collision.gameObject.GetComponent<PlayerHit>();
            inPlayer = true;
        }

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {

            inPlayer = false;
        }
    }
}
