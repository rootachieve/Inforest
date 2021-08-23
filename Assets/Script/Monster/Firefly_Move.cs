using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly_Move : MonoBehaviour
{
    public bool isIn;
    public Transform PT;
    public Transform FT;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        if (isIn)
        {
            if (FT.transform.position.x < PT.position.x)
            {
                FT.transform.position = new Vector3(FT.transform.position.x + 3 * Time.deltaTime, FT.transform.position.y, FT.transform.position.z);
            }
            else
            {
                FT.transform.position = new Vector3(FT.transform.position.x - 3 * Time.deltaTime, FT.transform.position.y, FT.transform.position.z);
            }


            if (FT.transform.position.y < PT.position.y)
            {
                FT.transform.position = new Vector3(FT.transform.position.x, FT.transform.position.y + 3 * Time.deltaTime, FT.transform.position.z);
            }
            else
            {
                FT.transform.position = new Vector3(FT.transform.position.x , FT.transform.position.y - 3 * Time.deltaTime, FT.transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10){
            isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10){
            isIn = false;
        }
    }
}
