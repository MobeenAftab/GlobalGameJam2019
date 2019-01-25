using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menu; //Needs to be assigned in editor

    public void enable()
    {
        menu.SetActive(true);
    }

    public void disable()
    {
        menu.SetActive(false);
    }
}
