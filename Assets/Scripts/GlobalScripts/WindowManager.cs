using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour
{
    //singleton
    public static WindowManager instance;

    //list of one of each window class
    public MainMenu main_menu;
    public JobSorter job_sorter;
    public JobMaker job_maker;
    public ScheduleManager schedule_manager;
    public ErrorScript error_window;

    //Awake function runs before the start function in unity
    private void Awake()
    {
        //setting the singleton object to this script
        instance = this;
    }

    private void Start()
    {
        main_menu.Init();
        job_sorter.Init();
        job_maker.Init();
        schedule_manager.Init();
        error_window.Init();
        JobDatabase.LoadDatabase();
    }

    public GameObject GetCurrentWindow()
    {
        //function to return the window that is currently open
        return EventSystem.current.currentSelectedGameObject;
    }
}
