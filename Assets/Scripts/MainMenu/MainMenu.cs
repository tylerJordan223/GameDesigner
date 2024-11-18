using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //actual window object
    [SerializeField] GameObject main_menu;

    private void Awake()
    {
        //load the database of schedules
        //LOAD DATABASE
        //show window since it is the first menu
        ShowWindow();
    }

    //window managing methods
    public void ShowWindow()
    {
        main_menu.SetActive(true);
    }
    public void HideWindow()
    {
        main_menu.SetActive(false);
    }

    //selections for other windows

    //quit the application
    public void QuitProgram()
    {
        Application.Quit();
    }
}
