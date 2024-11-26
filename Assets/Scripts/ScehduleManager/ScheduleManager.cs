using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    [SerializeField] GameObject job_prefab;
    [SerializeField] GameObject job_parent;
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
        UpdateSchedule();
        schedule_manager_go.SetActive(true);
    }
    public void HideWindow()
    {
        schedule_manager_go.SetActive(false);
        RemoveSchedule();
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
    //populates the actual schedule with the jobs
    public void UpdateSchedule()
    {
        for(int i = 0; i < JobDatabase.jobs.Count; i++)
        {
            //make a new job
            GameObject temp_job = Instantiate(job_prefab);
            //set the parent
            temp_job.transform.SetParent(job_parent.transform);
            //update the job
            temp_job.GetComponent<JobInSchedule>().UpdateJob(JobDatabase.jobs[i]);
            //update the scale of the job prefab object
            temp_job.GetComponent<RectTransform>().sizeDelta = new Vector2(temp_job.GetComponent<RectTransform>().sizeDelta.x + 200 * JobDatabase.jobs[i].getJobTime(), temp_job.GetComponent<RectTransform>().sizeDelta.y);
            //update the scale back to 1
            temp_job.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }
    }
    //clears the schedule when leaving the window
    public void RemoveSchedule()
    {
        for(int i = job_parent.transform.childCount-1; i >= 0; i--)
        {
            Destroy(job_parent.transform.GetChild(i).gameObject);
        }
    }
    #endregion OPTIONS
}
