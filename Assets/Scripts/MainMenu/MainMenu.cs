using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //actual window object
    private GameObject main_menu_go;

    //initialization in a custom method so it will be loaded when wanted instaed of at the start of a scene
    public void Init()
    {
        main_menu_go = gameObject;

        //load the database of schedules
        //LOAD DATABASE
        //show window since it is the first menu
        ShowWindow();
    }

    //window managing methods
    #region WINDOW
    public void ShowWindow()
    {
        main_menu_go.SetActive(true);
    }
    public void HideWindow()
    {
        main_menu_go.SetActive(false);
    }
    public bool IsVisible()
    {
        return main_menu_go.activeInHierarchy;
    }
    #endregion WINDOW

    //options
    #region OPTIONS
    public void PickJobMaker()
    {
        HideWindow();
        WindowManager.instance.job_maker.ShowWindow();
    }
    public void PickJobSorter()
    {
        HideWindow();
        WindowManager.instance.job_sorter.ShowWindow();
    }
    public void PickScheduleGenerator()
    {
        HideWindow();
        WindowManager.instance.schedule_manager.ShowWindow();
    }
    #endregion OPTIONS

    //quit the application
    public void QuitProgram()
    {
        //saves the data before quitting
        JobDatabase.SaveDatabase();
        Application.Quit();
    }
}
