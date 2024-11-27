using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobSorter : MonoBehaviour
{
    private GameObject job_sorter_go;

    [SerializeField] GameObject job_in_list;
    [SerializeField] GameObject content_parent;

    //for the breaks
    [SerializeField] GameObject break_menu;
    [SerializeField] TMP_InputField break_input;
    private int break_position;

    //initialization in a custom method so it will be loaded when wanted instaed of at the start of a scene
    public void Init()
    {
        job_sorter_go = gameObject;
        break_position = -1;

        HideWindow();
    }

    //window managing methods
    #region WINDOW
    public void ShowWindow()
    {
        UpdateList();
        job_sorter_go.SetActive(true);
    }
    public void HideWindow()
    {
        job_sorter_go.SetActive(false);
        break_menu.SetActive(false);
        RemoveList();
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

    #region LIST
    public void UpdateList()
    {
        for (int i = 0; i < JobDatabase.jobs.Count; i++)
        {
            //make a new job
            GameObject temp_job = Instantiate(job_in_list);
            //set the parent
            temp_job.transform.SetParent(content_parent.transform);
            //update the job
            temp_job.GetComponent<JobInSorter>().UpdateSorterJob(JobDatabase.jobs[i], i);
            //update the scale back to 1
            temp_job.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }
    }

    //clears the list when leaving the window
    public void RemoveList()
    {
        for (int i = content_parent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(content_parent.transform.GetChild(i).gameObject);
        }
    }

    //cycles the list quickly
    public void RefreshList()
    {
        RemoveList();
        UpdateList();
    }
    #endregion LIST

    #region BREAK
    public void StartBreak(int position)
    {
        break_menu.SetActive(true);
        break_position = position;
    }

    public void AddBreak()
    {
        //checking if it is a number that is within range
        if (!int.TryParse(break_input.text, out _))
        {
            WindowManager.instance.error_window.ShowError("Input must be a whole number!");
        }else if (int.Parse(break_input.text) <= 0)
        {
            WindowManager.instance.error_window.ShowError("Input must be greater than 0!");
        }else if (int.Parse(break_input.text) > 30)
        {
            WindowManager.instance.error_window.ShowError("Time cannot be over 30");
        }
        else
        {
            //adding the break in the right spot then refreshing
            JobDatabase.InsertJob(new Break(int.Parse(break_input.text)),break_position);
            RefreshList();
            break_input.text = "";
        }
    }

    public void CancelBreak()
    {
        break_input.text = "";
        break_menu.SetActive(false);
    }
    #endregion BREAK

    #endregion OPTIONS
}
