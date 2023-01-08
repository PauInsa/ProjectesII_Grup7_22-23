using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerMain : MonoBehaviour
{

    public AudioSource AudioSource;
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Modificado");
        AudioSource.Play();
    }

    public void EscenaOpciones()
    {
        SceneManager.LoadScene("Options");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
