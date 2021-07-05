using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public bool inPlayer = false;
    public PlayerState PS;
    public Rigidbody2D PR;
    PlayerHit PH;
    GameObject PL;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && inPlayer)
        {
            PS.moveAble = false;
            PS.isRope = true;
            PR.gravityScale = 0;
            PL.transform.position = new Vector3(transform.position.x, PL.transform.position.y, PL.transform.position.z);
            PR.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) && PS.isRope&&!PS.isAttack)
        {
            PL.transform.position = new Vector3(PL.transform.position.x, PL.transform.position.y + 4*Time.deltaTime, PL.transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow) && PS.isRope && !PS.isAttack)
        {
            PL.transform.position = new Vector3(PL.transform.position.x, PL.transform.position.y - 4*Time.deltaTime, PL.transform.position.z);
        }

        if (PS.isRope&&PH.invincibility > 0)
        {
            PS.moveAble = false;
            PS.isRope = false;
            PR.gravityScale = 1;
        }
        

        if (PS.isRope&&Input.GetKeyDown(KeyCode.Z))
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
            PL = collision.gameObject;
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
