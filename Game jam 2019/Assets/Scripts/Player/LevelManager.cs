/*
 * Level Manager is attached to player to detect win/lose conditions and 
 * object collision with the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    bool collisionsActive = true; // Collision detection to turn it on or off when transitioning scenes
    bool isTansitioning = false; // Scene transition, disable controls when moving between scenes
    private float transitionDelay = 2.0f; // Delay the scene transition


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // If scene is changing ignore the following update method calls
        if (!isTansitioning)
        {

        }

    }

    private void LevelComplete()
    {
        Debug.Log("Level Complete");
        Invoke("LoadNextLevel", transitionDelay);
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Invoked by LevelComplete(), Dont need this function, can invoke scene by build index
    /// Final scene in build order must be the win scene
    /// </summary>
    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        // Go through levels until win scene
        if (SceneManager.sceneCountInBuildSettings != nextScene)
        {
            SceneManager.LoadScene(nextScene);
        }
        // Or main menu
        else
        {
            // Default to main menu, maybe change to end game?
            LoadMainMenu();
        }
    }

    /// <summary>
    /// Load the main menu scene
    /// </summary>
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void EndGame()
    {
        SceneManager.LoadScene(3);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("LevelManager:" + collision);

        switch (collision.gameObject.tag)
        {
            case "Teddy":
                print("Player on Teddy");
                break;
            case "Finish": // Move this to teddy?
                LevelComplete();
                break;
            default:
                EndGame();
                break;
        }
    }
}
