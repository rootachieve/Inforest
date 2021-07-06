using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    public bool ishorizontal;//if Left or right => true
    public bool isUpLeft;//if Up or Left => true
    //combination [ishorizontal,isUpLeft] / left[true,true] right[true,false] up[false,true] down[false,false]
    public Rigidbody2D PlayerRg;
    public Transform PlayerTF;
    public Transform CameraTF;
    private Vector2 dummy1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (ishorizontal && isUpLeft)//If you go left, you'll see it on the right.
            {
                CameraTF.position = new Vector3(CameraTF.position.x+100, CameraTF.position.y, CameraTF.position.z);
                //I'm sending the camera to the other side.
                dummy1 = PlayerRg.velocity;//Record the player's Velocity.
                PlayerTF.position = new Vector3(PlayerTF.position.x+100, PlayerTF.position.y, PlayerTF.position.z);
                //I'm sending the player to the other side.
                PlayerRg.velocity = dummy1;//Applies the recorded velocity.
            }

            else if (ishorizontal && !isUpLeft)//right
            {
                CameraTF.position = new Vector3(CameraTF.position.x-100, CameraTF.position.y, CameraTF.position.z);


                dummy1 = PlayerRg.velocity;
                PlayerTF.position = new Vector3(PlayerTF.position.x-100, PlayerTF.position.y, PlayerTF.position.z);
                PlayerRg.velocity = dummy1;
            }

            else if (!ishorizontal && isUpLeft)//up
            {
              
                CameraTF.position = new Vector3(CameraTF.position.x, CameraTF.position.y-100, CameraTF.position.z);


                dummy1 = PlayerRg.velocity;
                PlayerTF.position = new Vector3(PlayerTF.position.x, PlayerTF.position.y-100, PlayerTF.position.z);
                PlayerRg.velocity = dummy1;
            }

            else if (!ishorizontal && !isUpLeft)//down
            {
               
                CameraTF.position = new Vector3(CameraTF.position.x, CameraTF.position.y+100, CameraTF.position.z);
                

                dummy1 = PlayerRg.velocity;
                PlayerTF.position = new Vector3(PlayerTF.position.x, PlayerTF.position.y+100, PlayerTF.position.z);
                PlayerRg.velocity = dummy1;
            }
        }

        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);//Delete the monster when it touches it
        }
    }
}
