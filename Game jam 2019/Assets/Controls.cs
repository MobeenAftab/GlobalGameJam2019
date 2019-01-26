using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#


public class Controls : MonoBehaviour
{
    public enum Controller { Player1, Player2 };
    public Controller playerController;
    int index;

    public bool leftTrigger;
    public bool rightTrigger;
    public float leftThumbStickY;
    public float leftThumbStickX;
    public float rightThumbStickY;
    public float rightThumbStickX;
    float triggerSensitivity = 0.01f;


    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Use this for initialization
    void Start()
    {
        if (playerController == Controller.Player1)
        {
            index = 0;
        }
        else
        {
            index = 1;
        }
    }

    void FixedUpdate()
    {
        if(playerController == Controller.Player1)
        {
            GamePad.SetVibration((PlayerIndex)0, state.Triggers.Left, 0);
        }
        else
        {
            GamePad.SetVibration((PlayerIndex)1, 0, state.Triggers.Right);
        }
    }

    // Update is called once per frame
    void Update()
    {

        PlayerIndex testPlayerIndex = (PlayerIndex)index;
        GamePadState testState = GamePad.GetState(testPlayerIndex);
        if (testState.IsConnected)
        {
          //  Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
            playerIndex = testPlayerIndex;
            playerIndexSet = true;
        }


        prevState = state;
        state = GamePad.GetState(playerIndex);

        if (playerController == Controller.Player1)
        {

            //Trigger code Player 1
            if (state.Triggers.Left > triggerSensitivity)
            {
                leftTrigger = true;
            }
            else
            {
                leftTrigger = false;
            }
            leftThumbStickY = state.ThumbSticks.Left.Y;
            leftThumbStickX = state.ThumbSticks.Left.X;

            /*
            // Detect if a button was pressed this frame
            if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed || state.Triggers.Left > 0.5)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            // Detect if a button was released this frame
            if (prevState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released && state.Triggers.Left < 0.5)
            {
                GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            */
        }
        else
        {
            //Trigger code Player 2
            if (state.Triggers.Right > triggerSensitivity)
            {
                rightTrigger = true;
            }
            else
            {
                rightTrigger = false;
            }

            rightThumbStickY = state.ThumbSticks.Right.Y;
            rightThumbStickX = state.ThumbSticks.Right.X;
        }

    }
}
