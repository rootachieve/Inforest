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
                CatchCount = 240f;
            }

            if (CatchCount < 120)
            {
                PS.moveAble = true;
                PS.isJump = false;
                Prigid.gravityScale = 1;
                spriteRenderer.sortingOrder = 1;
                isCatch = false;
                animator.SetBool("isCatch", false);
                count = 240f;
                isActive = false;
            }
        }

        if (CatchCount > 0)
        {
            CatchCount -= 1;
        }
        if (Ptransform.position.x < Mtransform.position.x)
        {
            if ((Ptransform.localScale.x > 0 && Mtransform.localScale.x > 0) || (Ptransform.localScale.x < 0 && Mtransform.localScale.x < 0))
            {
                isActive = false;
                animator.SetBool("isActive", false);
                count = 60f;
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
            if ((Ptransform.localScale.x > 0 && Mtransform.localScale.x < 0) || (Ptransform.localScale.x < 0 && Mtransform.localScale.x > 0))
            {
                isActive = false;
                animator.SetBool("isActive", false);
                count = 60f;
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
                PS.isDamage = true;
                spriteRenderer.sortingOrder = 3;
                Mtransform.position = new Vector3(Ptransform.position.x, Ptransform.position.y, Ptransform.position.z);
                isCatch = true;
                animator.SetBool("isCatch", true);
            }
        }
    }
}
