using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool gameOn; //Determines whether main game loop is running
    public MainMenu mainMenu;
    public static GameController instance; //Singleton

    void Awake()
    {
        gameOn = false;

        //Singleton check
        if(instance != null)
        {
            Destroy(this);
        }else
        {
            instance = this;
        }
    }

    //Should be called by a UI button on menu, assign in editor
    public void StartGame()
    {
        gameOn = true;
        mainMenu.disable();
    }

    void GameOver()
    {
        gameOn = false;
        mainMenu.enable();
    }
}
