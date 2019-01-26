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
        // Transition scence here
        Debug.Log("Level Complete");
        // Load next level
        //Invoke("loadNextLevel", transitionDelay);

    }

    private void PlayerDeath()
    {
    }

    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (SceneManager.sceneCountInBuildSettings != nextScene)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            LoadFirstLevel();
        }
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
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
                PlayerDeath();
                break;
        }
    }
}
