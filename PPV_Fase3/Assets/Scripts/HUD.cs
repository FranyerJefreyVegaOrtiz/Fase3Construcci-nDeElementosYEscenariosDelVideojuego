using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidasVerde;
    public GameObject[] vidasNaranja;
    public GameObject[] vidasRosa;
    public GameObject[] vidasPlayer;

    public void DesactivarVidaVerde(int indice)
    {
        vidasVerde[indice].SetActive(false);
    }
    public void DesactivarVidaNaranja(int indice)
    {
        vidasNaranja[indice].SetActive(false);
    }
    public void DesactivarVidaRosa(int indice)
    {
        vidasRosa[indice].SetActive(false);
    }
    public void DesactivarVidaPlayer(int indice)
    {
        vidasPlayer[indice].SetActive(false);
    }
}
