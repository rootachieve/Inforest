using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject outObj;
    bool isIn = false;
    public Collider2D player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isIn == true && transform.GetComponent<PortalState>().isOpen)
        {
            player.transform.position = outObj.transform.position;
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
