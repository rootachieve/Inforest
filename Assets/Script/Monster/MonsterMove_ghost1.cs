using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove_ghost1 : MonoBehaviour
{
    public MonsterState MS;
    public int Count;
    public bool inplayer=false;
    public Transform M;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        Count++;
        if (!inplayer)
        {
            if (Count <= 120)
            {
                if (MS.moveAble)//left move if moveable is true
                {

                    if (M.localScale.x < 0) // Change the scale to negative or positive so that the character is completely flipped.
                    {
                        M.localScale = new Vector3(M.localScale.x * -1, M.localScale.y, M.localScale.z);
                    }
                    M.position = new Vector3(M.position.x + MS.moveSpeed * Time.deltaTime, M.position.y, M.position.z);
                    //move

                    MS.isMove = true;//move motion
                }
            }
            else if (Count <= 180)
            {
                MS.isMove = false;
            }
            else if (Count <= 300)
            {
                if (MS.moveAble)//left move if moveable is true
                {

                    if (M.localScale.x > 0)//Same as above
                    {
                        M.localScale = new Vector3(M.localScale.x * -1, M.localScale.y, M.localScale.z);
                    }
                    M.position = new Vector3(M.position.x + -MS.moveSpeed * Time.deltaTime, M.position.y, M.position.z);

                    MS.isMove = true;

                }
            }
            else if (Count <= 360)
            {
                MS.isMove = false;
            }
            else
            {
                Count = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            MS.moveAble = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 10)
        {
            inplayer = true;
            if (MS.moveAble)
            {
                if (collision.gameObject.GetComponent<Transform>().position.x > M.position.x)
                {
                    M.position = new Vector3(M.position.x + MS.moveSpeed * Time.deltaTime, M.position.y, M.position.z);
                }
                else
                {
                    M.position = new Vector3(M.position.x + -MS.moveSpeed * Time.deltaTime, M.position.y, M.position.z);
                }
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            inplayer = false;
        }
    }
}
