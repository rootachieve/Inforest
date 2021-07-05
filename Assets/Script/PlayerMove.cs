using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerState PS;
    public Rigidbody2D PR;//player rigidbody

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKey(KeyCode.RightArrow) && PS.moveAble)//������ �̵�
        {
            if (!Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.localScale.x < 0) //������ȯ
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                transform.position = new Vector3(transform.position.x + PS.moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                //�̵�

                PS.isMove = true;//�̵� ��
            }
            else
            {
                PS.isMove = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) && PS.moveAble)
        {
            if (!Input.GetKey(KeyCode.RightArrow))//������ �̵�
            {
                if (transform.localScale.x > 0)
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
            PS.isMove = false;//����
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            PS.isMove = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) && PS.moveAble && !PS.isJump)//����
        {
            PS.isJump = true;
            PR.AddForce(new Vector2(0,PS.jumpPower),ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PS.isJump = false;
            PR.velocity = new Vector2(PR.velocity.x, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PS.isJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PS.isJump = true;
        }
    }
    
}
