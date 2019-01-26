/*
 * Teddy script will detect collision with other object.
 */
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour
{
    bool collisionsActive = true;
    bool isTansitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If Teddy is not moving
        if (!isTansitioning)
        {
            // If not moving and collision with chest == win game
           
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);

        // If teddy is stationary and not colliding with object exit function
        if (isTansitioning || !collisionsActive)
        {
            return;
        }

        // If stationary and collision == true
        switch (collision.gameObject.tag)
        {
            case "Player":
                print("Teddy on Player");
                break;
            case "Finish":
                // Teddy is in chest area
                Debug.Log("Teddy in Chest, Finish");
                break;
            default:
                Debug.Log("Teddy Default");
                break;
        }
    }
}
