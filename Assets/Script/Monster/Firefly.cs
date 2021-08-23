using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    public int count=10;
    public bool IsIn;
    public PlayerState PS;
    public SpriteRenderer SR;
    public GameObject GF;
    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {

            GF.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.C) && IsIn)
        {
            count--;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            IsIn = true;
            PS.moveSpeed = 1.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            IsIn = false;
            PS.moveSpeed = 3.5f;
        }
    }
}
