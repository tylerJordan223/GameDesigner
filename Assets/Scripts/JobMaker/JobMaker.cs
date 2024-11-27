using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobMaker : MonoBehaviour
{
    private GameObject job_maker_go;

    //list of input fields
    [SerializeField] private TMP_InputField job_name;
    [SerializeField] private TMP_InputField job_description;
    [SerializeField] private TMP_InputField job_time;

    //initialization in a custom method so it will be loaded when wanted instaed of at the start of a scene
    public void Init()
    {
        job_maker_go = gameObject;

        HideWindow();
    }

    //window managing methods
    #region WINDOW
    public void ShowWindow()
    {
        job_maker_go.SetActive(true);
    }
    public void HideWindow()
    {
        job_maker_go.SetActive(false);
    }
    public bool IsVisible()
    {
        return job_maker_go.activeInHierarchy;
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

    //job creation
    public void CreateJob()
    {
        if(job_name.text.Length <= 0)
        {
            WindowManager.instance.error_window.ShowError("Job needs a title!");
        }else if(job_description.text.Length <= 0)
        {
            WindowManager.instance.error_window.ShowError("Job needs a description!");
        }else if(!int.TryParse(job_time.text, out _))
        {
            //checks if the input field is a number
            WindowManager.instance.error_window.ShowError("Time needs to be a whole number!");
        }else if (int.Parse(job_time.text) > 30)
        {
            WindowManager.instance.error_window.ShowError("Time cant be more than 30 days");
        }else if (int.Parse(job_time.text) < 1)
        {
            WindowManager.instance.error_window.ShowError("Time has to be at least 1 day");
        }
        else
        {
            //adds the new job to the database
            JobDatabase.AddJob(new Job(job_name.text, job_description.text, int.Parse(job_time.text), false));

            //clears the menu
            job_name.text = "";
            job_description.text = "";
            job_time.text = "";
        }
    }
}
