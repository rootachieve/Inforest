using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject Pause;
    public ChatManager manager;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if(paused)
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
        if(!paused)
        {
            Pause.SetActive(false);
            if(!manager.isAction)
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void Resume()
    {
        paused = !paused;
    }
    public void MainMenu()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
