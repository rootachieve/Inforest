using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWall : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 10);//Monster and Player Not Conflicting
        Physics2D.IgnoreLayerCollision(11, 9);//Monster and PlayerSide Not Conflicting
        Physics2D.IgnoreLayerCollision(11, 8);//Monster and Player Not Conflicting
        Physics2D.IgnoreLayerCollision(11, 6);//Monster and PlayerSide Not Conflicting
    }
}
