using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject outObj;
    bool isIn = false;
    public Collider2D player;
    public int cooltime;
    //public FadeInOut FadeInOut;
    void Update()
    {
        if (cooltime > 0)
        {
            cooltime--;
        }
        if (Input.GetKeyDown(KeyCode.C) && isIn == true && transform.GetComponent<PortalState>().isOpen && cooltime == 0)
        {
            //FadeInOut.Fadeout();
            player.transform.position = outObj.transform.position;
            outObj.GetComponent<Portal>().cooltime = 60;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isIn = false;
        }
    }
}