using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuPause;
    private bool menuOn;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuOn = !menuOn;
        }

        if (menuOn)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            menuPause.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
