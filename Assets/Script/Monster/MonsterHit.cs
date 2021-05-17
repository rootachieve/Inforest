using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    public MonsterState MS;//monsterstate
    public float invincibility;
    public SpriteRenderer S;//monster sprite

    private Color iv_C = new Color(0.5f, 0.5f, 0.5f, 1f);//gray
    private Color mi_C = new Color(1f, 1f, 1f, 1f);//white
    // Start is called before the first frame update

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (MS.health <= 0)
        {
            MS.death = true;//death
        }
        else
        {
            if (invincibility > 0)
            {
                if (((int)invincibility / 5) % 2 == 1)//blinking
                {
                    S.color = iv_C;
                }
                else
                {
                    S.color = mi_C;
                }
                invincibility--;//invincibility time reduce;
            }
        }
    }
}
