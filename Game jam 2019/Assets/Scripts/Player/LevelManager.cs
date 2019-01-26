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
    bool collisionsActive = true;
    bool isTansitioning = false;
    private float transitionDelay = 2.0f;

    //Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player is moving
        if (isTansitioning)
        {

        }

    }

    private void LevelComplete()
    {
        Debug.Log("Level Complete");
        // Load next level
        Invoke("LoadNextLevel", transitionDelay);
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
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
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);

        // Check to see if teddy is moving
        if (!collisionsActive)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Teddy":
                print("Player on Teddy");
                break;
            case "Finish":
                LevelComplete();
                break;
            default:
                EndGame();
                break;
        }
    }
}
