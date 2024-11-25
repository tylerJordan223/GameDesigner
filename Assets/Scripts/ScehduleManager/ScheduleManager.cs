using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    private GameObject schedule_manager_go;

    //initialization in a custom method so it will be loaded when wanted instaed of at the start of a scene
    public void Init()
    {
        schedule_manager_go = gameObject;

        HideWindow();
    }

    //window managing methods
    #region WINDOW
    public void ShowWindow()
    {
        schedule_manager_go.SetActive(true);
    }
    public void HideWindow()
    {
        schedule_manager_go.SetActive(false);
    }
    public bool IsVisible()
    {
        return schedule_manager_go.activeInHierarchy;
    }
    #endregion WINDOW

    //options
    #region OPTIONS
    public void ReturnToMenu()
    {
        HideWindow();
        WindowManager.instance.main_menu.ShowWindow();
    }
    #endregion OPTIONS
}
