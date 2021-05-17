using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    float CameraZ = -20;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 10);//Monster and Player Not Conflicting
        Physics2D.IgnoreLayerCollision(8, 9);//Monster and PlayerSide Not Conflicting
        Camera.main.aspect = 16f / 9f; //Screen Ratio 16 to 9 Fixed
        Screen.SetResolution(1920, 1080, true); //Resolution 1920¡¿1080 Full Screen = true
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y, CameraZ), Time.deltaTime * 1f);
        //Smooth player tracking
    }

}