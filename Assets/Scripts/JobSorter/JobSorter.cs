using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobSorter : MonoBehaviour
{
    private GameObject job_sorter_go;

    //initialization in a custom method so it will be loaded when wanted instaed of at the start of a scene
    public void Init()
    {
        job_sorter_go = gameObject;

        HideWindow();
    }

    //window managing methods
    #region WINDOW
    public void ShowWindow()
    {
        job_sorter_go.SetActive(true);
    }
    public void HideWindow()
    {
        job_sorter_go.SetActive(false);
    }
    public bool IsVisible()
    {
        return job_sorter_go.activeInHierarchy;
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
