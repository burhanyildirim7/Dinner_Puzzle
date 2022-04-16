using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance; // singleton yapisi icin gerekli ornek ayrintilar icin BeniOku 22. satirdan itibaren bak.


    [HideInInspector]public int score, elmas; // ayrintilar icin benioku 9. satirdan itibaren bak

    [HideInInspector] public bool isContinue,masaDolu;  // ayrintilar icin beni oku 19. satirdan itibaren bak


	private void Awake()
	{
        if (instance == null) instance = this;
        //else Destroy(this);
	}

	void Start()
    {
       isContinue = false;
        StartingEvents();
    }


    public void SetScore(int eklenecekScore)
	{
        if(PlayerController.instance.collectibleVarMi) score += eklenecekScore;
        // Eðer oyunda collectible yok ise developer kendi score sistemini yazmalý...

    }

    public void StartingEvents()
	{
        masaDolu = false;
	}

}
