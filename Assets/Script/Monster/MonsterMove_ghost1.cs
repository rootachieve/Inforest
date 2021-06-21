using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove_ghost1 : MonoBehaviour
{
    public MonsterState MS;
    public int Count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Count++;
        if (Count <= 120)
        {
            if (MS.moveAble)//left move if moveable is true
            {

                if (transform.localScale.x < 0) // Change the scale to negative or positive so that the character is completely flipped.
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                transform.position = new Vector3(transform.position.x + MS.moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                //move

                MS.isMove = true;//move motion
            }
        }else if (Count <= 180)
        {
            MS.isMove = false;
        }else if (Count <= 300)
        {
            if (MS.moveAble)//left move if moveable is true
            {

                if (transform.localScale.x > 0)//Same as above
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                transform.position = new Vector3(transform.position.x + -MS.moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

                MS.isMove = true;

            }
        }else if (Count <= 360)
        {
            MS.isMove = false;
        }
        else
        {
            Count = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            MS.moveAble = true;
        }
    }

}
