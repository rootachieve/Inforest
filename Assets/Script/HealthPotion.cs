using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public PlayerState PS;
    public bool Playerin;
    public int heal = 5;//heal amount
    public GameObject particle;
    private bool healing;//healing

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Playerin&&!PS.isGameover&&!healing)
        {//The character is touching the potion, not healing, and if you press c
            healing = true;
            if (PS.health + heal <= PS.maxHealth) //Control does not exceed maximum maxHealth.
            {
                PS.health += heal;
            }
            else
            {
                PS.health = PS.maxHealth;
            }
            particle.SetActive(true);//Show particles and remove after 0.5 seconds.
            Destroy(gameObject, 0.5f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            Playerin = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Playerin = false;
        }
    }
}
