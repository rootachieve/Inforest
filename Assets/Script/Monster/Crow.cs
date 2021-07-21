using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public GameObject pear;
    //When the character enters the range, it has no function other than making the pear move and initialize.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            pear.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            pear.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, 0);
            pear.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pear.SetActive(false);
        }
    }
}
