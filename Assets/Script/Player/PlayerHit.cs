using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerState PS;//Player State
    public float invincibility;
    public SpriteRenderer S;//Player Sprite
    private Color iv_C = new Color(0.5f, 0.5f, 0.5f, 1f);//gray
    private Color mi_C = new Color(1f, 1f, 1f, 1f);//white
    // Start is called before the first frame update
    public Transform Camera; //Å¸°Ý°¨
    // Update is called once per frame

    private void FixedUpdate()
    {
        if (PS.health <= 0)
        {
            PS.isGameover = true;//Gameover
        }
        else
        {
            if (invincibility > 0)//invincible time (under attack)
            {
                if (((int)invincibility / 5) % 2 == 1)//Blinking
                {
                    S.color = iv_C;
                }
                else
                {
                    S.color = mi_C;
                }

                if (((int)invincibility - 5) % 10 == 0)
                {
                    Camera.position = new Vector3(Camera.position.x + 0.002f * invincibility, Camera.position.y, Camera.position.z);
                }
                else if (((int)invincibility) % 10 == 0)
                {
                    Camera.position = new Vector3(Camera.position.x - 0.002f * invincibility, Camera.position.y, Camera.position.z);
                }
                invincibility--;//invincibility time reduce;

                
            }
        }
    }
}
