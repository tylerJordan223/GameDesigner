using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JobInSorter : MonoBehaviour
{
    //script to handle each job visually when the Sorting list is generated
    [SerializeField] TextMeshProUGUI job_title;
    [SerializeField] TextMeshProUGUI job_time;
    [SerializeField] TextMeshProUGUI job_order;

    private int my_job_index;

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void UpdateSorterJob(Job j, int order)
    {
        job_title.text = j.getJobTitle();
        job_time.text = "Days: " + j.getJobTime().ToString();
        job_order.text = order.ToString();
        my_job_index = order;
    }

    //functions for the different buttons
    #region options
    //move the job up in the order
    public void JobUp()
    {
        //get the index of the job to be moved up (higher on the list)
        int job_index = my_job_index;
        if (job_index == 0)
        {
            //error catch for the job being first in the list
            WindowManager.instance.error_window.ShowError("Job cannot be higher");
        }
        else
        {
            //get the job and replace it , then put it where my_job is
            Job temp_job = JobDatabase.jobs[job_index - 1];
            JobDatabase.jobs[job_index - 1] = JobDatabase.jobs[job_index];
            JobDatabase.jobs[job_index] = temp_job;
        }

        //refresh the list
        WindowManager.instance.job_sorter.RefreshList();
    }

    //move hte job down in the order
    public void JobDown()
    {
        //get the index of the job to be moved down (lower on the list)
        int job_index = my_job_index;
        if (job_index == JobDatabase.jobs.Count-1)
        {
            //error catch for the job being first in the list
            WindowManager.instance.error_window.ShowError("Job cannot be lower");
        }
        else
        {
            //get the job and replace it , then put it where my_job is
            Job temp_job = JobDatabase.jobs[job_index + 1];
            JobDatabase.jobs[job_index + 1] = JobDatabase.jobs[job_index];
            JobDatabase.jobs[job_index] = temp_job;
        }

        //refresh the list
        WindowManager.instance.job_sorter.RefreshList();
    }

    //add a break below this job
    public void AddBreak()
    {
        //tells the sorter to add a break in the position after this job
        if(my_job_index == JobDatabase.jobs.Count-1)
        {
            WindowManager.instance.error_window.ShowError("Break cannot be placed at the end");
        }
        else
        {
            WindowManager.instance.job_sorter.StartBreak(my_job_index + 1);
        }
    }

    //delete the job from the database
    public void DeleteJob()
    {
        JobDatabase.jobs.Remove(JobDatabase.jobs[my_job_index]);
        WindowManager.instance.job_sorter.RefreshList();
    }
    #endregion options
}
