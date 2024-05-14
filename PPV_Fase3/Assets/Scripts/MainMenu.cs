using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("juego");
    }

    public void EscenaMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
