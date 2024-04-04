using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int VidaPlayer = 3;

    public static GameManager instance { get; private set; }

    public Text textVidaPlayer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        textVidaPlayer.text = VidaPlayer.ToString();
    }
}
