using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    public GameObject Select;
    public GameObject Main;
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Stage 0");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Main.SetActive(false);
        Select.SetActive(true);
    }
    public void BacktoTitle()
    {
        Main.SetActive(true);
        Select.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Main.SetActive(true);
        Select.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
