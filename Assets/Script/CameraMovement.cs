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
        Camera.main.aspect = 16f / 9f; //화면 비율 16대 9로 고정
        Screen.SetResolution(1920, 1080, true); //해상도 1920 1080, 전체화면 true
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y, CameraZ), Time.deltaTime * 1f);
        //부드러운 목표 주적
    }

}