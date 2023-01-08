using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemanagerEngine : MonoBehaviour
{
    public Trampilla trampillaScript;
    public Puerta DoorScript;
    public string Level;


    void Update()
    {
        if (trampillaScript.In == true && DoorScript.In == true)
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(Level);
    }
}

