/*
 * Teddy script will detect collision with other object.
 */
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teddy : MonoBehaviour
{
  
    private void WinGame()
    {
        SceneManager.LoadScene(2);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);

        // If stationary and collision == true
        switch (collision.gameObject.tag)
        {
            case "Player":
                print("Teddy on Player");
                WinGame();
                break;
            case "Finish":
                // Teddy is in chest area
                Debug.Log("Teddy in Chest, Finish");
                WinGame();
                break;
            default:
                Debug.Log("Teddy Collided with" + collision.gameObject.tag);
                break;
        }
    }
}
