using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow_pear : MonoBehaviour
{
    public Transform PL;
    public PlayerState PS;
    public int str = 3;
    private Vector2 knockBack_R = new Vector2(4f, 3f);//knockBack to the right
    private Vector2 knockBack_L = new Vector2(-4f, 3f);//knockBack to the left
    public bool isDrop;


    public Vector3 start;
    public float doubleV;
    public float v;
    public float t;
    public float xv;

    private void Start()
    {
        start = new Vector3(transform.position.x, transform.position.y, 0);//the initial position of a pear
    }
 
    void Update()
    {
        if (!isDrop)
        {//Based on the position of the character and the position of the crow, it is determined what speed to throw the pear at.
            isDrop = true;
             doubleV = 19.6f * (transform.position.y - PL.position.y);//2as = v^2-v0^2
            v = Mathf.Sqrt(Mathf.Abs(doubleV));//sqrt(v^2) = v,  abs(-v) = v
            t = v / 9.8f;//v=at , t=v/a
           xv = (transform.position.x - PL.position.x) / t;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-xv, 0);//velocity
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)//If the player is in the monster's hit point.
        {
            if (collision.gameObject.GetComponent<PlayerHit>().invincibility <= 0 && PS.health > 0)
            {//If a player has not invincible ,if the monster health is above zero, and the player health is above zero
                PS.isDamage = true;
                PS.moveAble = false; //Can't move because it's under attack.
                if (PS.health - str > 0)//Prevent health from being negative
                {
                    PS.health -= str; //health reduce
                }
                else
                {
                    PS.health = 0;
                }
                collision.gameObject.GetComponent<PlayerHit>().invincibility = 120f;//player invincibility (2 sec)

                if (transform.position.x > collision.gameObject.GetComponent<Transform>().position.x)//Relative Position of Players and Monsters
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockBack_L, ForceMode2D.Impulse);//knockBack
                }
                else
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockBack_R, ForceMode2D.Impulse);//knockBack
                }
            }
        }

        if(collision.gameObject.layer == 6)
        {
            transform.position = start;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            isDrop = false;
            //Initialization
        }
    }


}
