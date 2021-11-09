using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Transform Mtransform;
    public PlayerState PS;
    public  Transform Ptransform;
    public Rigidbody2D Prigid;
    public  MonsterState MS;
    public Animator animator;
    public bool isActive = true;
    public bool isCatch = false;
    public float count = 60f;
    public float CatchCount = 0f;

    int bef=0;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (!isCatch && isActive)
        {
            if (Ptransform.position.x < Mtransform.position.x)
            {
                if(Mtransform.localScale.x != 0.7)
                {
                    Mtransform.localScale = new Vector3(0.7f, Mtransform.localScale.y, Mtransform.localScale.z);
                }
                Mtransform.position = new Vector3(Mtransform.position.x - MS.moveSpeed * Time.deltaTime, Mtransform.position.y, Mtransform.position.z);
            }
            else
            {
                if (transform.localScale.x != -0.7)
                {
                    Mtransform.localScale = new Vector3(-0.7f, Mtransform.localScale.y, Mtransform.localScale.z);
                }
                Mtransform.position = new Vector3(Mtransform.position.x + MS.moveSpeed * Time.deltaTime, Mtransform.position.y, Mtransform.position.z);

            }
        }else if (isCatch)
        {
            if (CatchCount <= 0)
            {
                CatchCount = 720f;
                bef = 0;
                Ptransform.position = new Vector3(Mtransform.position.x,Mtransform.position.y-1,Mtransform.position.z);
            }

            if (CatchCount < 400)
            {
                PS.moveAble = true;
                PS.isJump = false;
                Prigid.gravityScale = 1;
                spriteRenderer.sortingOrder = 1;
                isCatch = false;
                animator.SetBool("isCatch", false);
                count = 400f;
                isActive = false;
            }
        }

        if (CatchCount > 0)
        {
            CatchCount -= 1;
            if (CatchCount >= 400)
            {
                switch (bef)
                {
                    case 0:
                        if (CatchCount <= 720)
                        {
                            bef++;
                            PS.health--;
                        }
                        break;
                    case 1:
                        if (CatchCount <= 656)
                        {
                            bef++;
                            PS.health--;
                        }
                        break;
                    case 2:
                        if (CatchCount <= 592)
                        {
                            bef++;
                            PS.health--;
                        }
                        break;
                    case 3:
                        if (CatchCount <= 528)
                        {
                            bef++;
                            PS.health--;
                        }
                        break;
                    case 4:
                        if (CatchCount <= 464)
                        {
                            bef++;
                            PS.health--;
                        }
                        break;

                }
            }
            
        }
        if (Ptransform.position.x < Mtransform.position.x)
        {
            if (Ptransform.localScale.x > 0)
            {
                animator.SetBool("isActive", false);
                if (count <= 240)
                {
                    isActive = false;
                  
                    count = 240f;
                }
            }
            else
            {
                if (!isActive)
                {
                    count -= 1;
                    
                    if (count < 0)
                    {
                        isActive = true;
                        animator.SetBool("isActive", true);

                    }
                }
            }
        }else if(Ptransform.position.x >= Mtransform.position.x)
        {
            if (Ptransform.localScale.x < 0)
            {
                animator.SetBool("isActive", false);
                if (count <= 240)
                {
                    isActive = false;
                   
                    count = 240f;
                }
            }
            else
            {
                if (!isActive)
                {
                    count -= 1;
                    if (count < 0)
                    {
                        isActive = true;
                        animator.SetBool("isActive", true);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            Debug.Log("´êÀ½");
            if (isActive&&CatchCount<=0)
            {
                Prigid.gravityScale = 0;
                PS.moveAble = false;
                Prigid.velocity = new Vector2(0, 0);
                PS.isDamage = true;
                spriteRenderer.sortingOrder = 3;
                isCatch = true;
                animator.SetBool("isCatch", true);
            }
        }
    }
}
