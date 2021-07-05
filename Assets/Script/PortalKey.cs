using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject portal1;
    public GameObject portal2;
    bool isIn;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isIn == true)
        {
            portal1.GetComponent<PortalState>().isOpen = true;
            portal2.GetComponent<PortalState>().isOpen = true;
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
