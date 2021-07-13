using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public Transform MT;//Monster Transform
    public MonsterState MS;//monster state
    public PlayerState PS;//player state
    private Vector2 knockBack_R = new Vector2(4f, 3f);//knockBack to the right
    private Vector2 knockBack_L = new Vector2(-4f, 3f);//knockBack to the left


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerStay2D(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)//If the player is in the monster's hit point.
        {
            if (collision.gameObject.GetComponent<PlayerHit>().invincibility <= 0 && PS.health > 0 && MS.health > 0)
            {//If a player has not invincible ,if the monster health is above zero, and the player health is above zero
                PS.isDamage = true;
                PS.moveAble = false; //Can't move because it's under attack.
                if (PS.health - MS.str > 0)//Prevent health from being negative
                {
                    PS.health -= MS.str; //health reduce
                }
                else
                {
                    PS.health = 0;
                }
                collision.gameObject.GetComponent<PlayerHit>().invincibility = 120f;//player invincibility (2 sec)

                if (MT.position.x > collision.gameObject.GetComponent<Transform>().position.x)//Relative Position of Players and Monsters
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockBack_L, ForceMode2D.Impulse);//knockBack
                }
                else
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockBack_R, ForceMode2D.Impulse);//knockBack
                }
            }
        }

    }

}
