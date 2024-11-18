using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour
{
    //singleton
    public static WindowManager instance;

    //list of one of each window class

    //Awake function runs before the start function in unity
    private void Awake()
    {
        //setting the singleton object to this script
        instance = this;
    }

    //initialize all the other windows
    private void Start()
    {
        
    }

    public GameObject GetCurrentWindow()
    {
        //function to return the window that is currently open
        return EventSystem.current.currentSelectedGameObject;
    }
}
