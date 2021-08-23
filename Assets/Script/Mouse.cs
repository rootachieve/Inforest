using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool isQte;//Qte has been triggered
    public bool setting;//running once
    public float count;//
    public int set;//Randomly determine which key to press
    public bool clear;// if qte is clear then true
    public bool fail;//fail
    public MonsterState mouse;//mouse state
    public Camera C;//camera
    public GameObject M;//mouse object
    public GameObject G;//g key
    public GameObject U;//u key
    public GameObject N;//n key
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (isQte)
        {
            if (!setting)//running once
            {
                count = 60f;//countdown
                Time.timeScale = 0.1f;//time slow
                set = Random.Range(1, 3);
                switch (set)//Show images according to a set key
                {
                    case 1:
                        G.SetActive(true);
                        break;
                    case 2:
                        U.SetActive(true);
                        break;
                    case 3:
                        N.SetActive(true);
                        break;
                }
                setting = true;
                C.orthographicSize = 3;//zoom in
            }

            count -= 300 * Time.deltaTime;//countdown

            if (Input.GetKeyDown(KeyCode.G) && set == 1)//Press the appropriate key to succeed
            {
                clear = true;
                G.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.U) && set == 2)
            {
                clear = true;
                U.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.N) && set == 3)
            {
                clear = true;
                N.SetActive(false);
            }

            if (count <= 0)//fail
            {
                Time.timeScale = 1;
                isQte = false;
                setting = false;
                C.orthographicSize = 7f;//zoom out
                M.GetComponent<MonsterState>().moveSpeed = 4f;//The mouse didn't disappear and turned around.
                G.SetActive(false);
                U.SetActive(false);
                N.SetActive(false);
                fail = true;
                //clear = true;
            }

            if (clear)
            {
                Time.timeScale = 1;
                isQte = false;
                setting = false;
                C.orthographicSize = 7f;
                mouse.health = 0;//mouse death
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10&&(!clear||!fail))
        {
            int a = Random.Range(1, 10);
            if (a <= 3)
            {
                M.SetActive(true);
                M.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
                isQte = true;
            }
        }
    }
}
