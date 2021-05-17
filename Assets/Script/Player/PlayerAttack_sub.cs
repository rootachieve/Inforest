using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_sub : MonoBehaviour
{
    public Transform PT;//Player Transform
    public PlayerState PS;//Player State
    private Vector2 knockBack_R =  new Vector2(4f, 3f);//knockBack to the right
    private Vector2 knockBack_L = new Vector2(-4f, 3f);//knockBack to the left

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerStay2D(collision); //call
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)//If the monster is in the player's hit point.
        {
            if (collision.gameObject.GetComponent<MonsterHit>().invincibility <= 0 && collision.gameObject.GetComponent<MonsterState>().health > 0 && PS.health>0)
            {//If a monster has not invincible ,if the monster health is above zero, and the player health is above zero
                collision.gameObject.GetComponent<MonsterState>().health -= PS.str;//monster health reduce
                collision.gameObject.GetComponent<MonsterHit>().invincibility = 60f;//monster invincibility (1 sec)
                if (PT.position.x > collision.gameObject.GetComponent<Transform>().position.x) //Relative Position of Players and Monsters
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
