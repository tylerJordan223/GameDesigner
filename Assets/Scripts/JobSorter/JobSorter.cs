using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobSorter : MonoBehaviour
{
    private GameObject job_sorter_go;

    [SerializeField] GameObject job_in_list;
    [SerializeField] GameObject content_parent;

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
        UpdateList();
        job_sorter_go.SetActive(true);
    }
    public void HideWindow()
    {
        job_sorter_go.SetActive(false);
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
    #endregion OPTIONS
}
