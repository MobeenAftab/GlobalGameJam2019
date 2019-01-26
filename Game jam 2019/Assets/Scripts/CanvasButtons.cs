using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtons: MonoBehaviour
{
    
    public void NewGameButton()
    {
        Debug.Log("NEW GAME SCENE...");
        SceneManager.LoadScene(1);
    }

    public void QuitGameButton()
    {
        Debug.Log("QUITING GAME...");
        Application.Quit();
    }

    public void MenuButton()
    {
        Debug.Log("REPLAYING GAME...");
        SceneManager.LoadScene(0);
    }
}
