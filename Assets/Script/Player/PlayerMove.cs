using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerState PS;//Player State;
    public Rigidbody2D PR;//player rigidbody

    public ChatManager manager;

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightArrow) && PS.isRope)//It's the movement when you're holding the rope.
        {
            if (transform.localScale.x < 0) // Change the scale to negative or positive so that the character is completely flipped.
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && PS.isRope)//It's the movement when you're holding the rope.
        {
            if (transform.localScale.x > 0) // Change the scale to negative or positive so that the character is completely flipped.
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && PS.moveAble&&!PS.isAttack)//right move if moveable is true
        {
            if (!Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.localScale.x < 0) // Change the scale to negative or positive so that the character is completely flipped.
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                transform.position = new Vector3(transform.position.x + PS.moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                //move

                PS.isMove = true;//move motion
            }
            else
            {
                PS.isMove = false;//If both keys are pressed at the same time, stop.
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) && PS.moveAble&&!PS.isAttack)//left move if moveable is true
        {
            if (!Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.localScale.x > 0)//Same as above
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                transform.position = new Vector3(transform.position.x + -PS.moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

                PS.isMove = true;
            }
            else
            {
                PS.isMove = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PS.isMove = false;//move motion stop
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            PS.isMove = false;// Same as above
        }

        if (Input.GetKeyDown(KeyCode.Z) && PS.moveAble && !PS.isJump&& PR.velocity.y==0&& !PS.isAttack)//jump // if move able is true, not already jump, y-axis velocity  0
        {
            PS.isJump = true;//jump motion
            PR.AddForce(new Vector2(0,PS.jumpPower),ForceMode2D.Impulse);//AddForce
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.Action();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)//Character touches the floor
        {
            PS.isJump = false;//jump motion stop
            PS.moveAble = true;//Character can move.
            if (PS.isRope)
            {
                PS.isRope = false;
                PR.gravityScale = 1;
            }
        }

        
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)//Character continuously touches the floor
        {
            PS.isJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //Character falls off the floor
        {
            PS.isJump = true;
        }
    }
}
