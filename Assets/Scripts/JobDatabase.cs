using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class JobDatabase : MonoBehaviour
{
    public static List<Job> jobs;

    public static void LoadDatabase()
    {
        //create the list to store all the jobs
        jobs = new List<Job>();
    }

    public static void AddJob(Job j)
    {
        jobs.Add(j);
    }

    //inserts a job in a certain position
    public static void InsertJob(Job j, int position)
    {
        //saves all jobs from position to the end in new list, removes them all, then adds the new one and the rest back.
        List<Job> saved_jobs = new List<Job>();

        for(int i = position; i < jobs.Count; i++)
        {
            saved_jobs.Add(jobs[i]);
        }
        for (int i = position; i < jobs.Count; i++)
        {
            jobs.Remove(jobs[i]);
        }

        jobs.Add(j);

        for(int i = 0; i < saved_jobs.Count; i++)
        {
            jobs.Add(saved_jobs[i]);
        }
    }

    public void SaveDatabase()
    {

    }
}

//job class
public class Job
{
    private string title;
    private string desc;
    private int time;
    public bool is_break;

    public Job(string _title, string _desc, int _time, bool _is_break)
    {
        title = _title;
        desc = _desc;
        time = _time;
        is_break = _is_break;
    }

    //base constructor for breaks to use
    public Job(int _time)
    {
        title = "";
        desc = "";
        is_break = false;
        time = _time;
    }

    #region getters/setters
    public string getJobTitle()
    {
        return title;
    }

    public void setJobTitle(string _title)
    {
        title = _title;
    }

    public string getJobDescription()
    {
        return desc;
    }

    public void setJobDescription(string _desc)
    {
        desc = _desc;
    }

    public int getJobTime()
    {
        return time;
    }

    public void setJobTime(int _time)
    {
        time = _time;
    }
    #endregion

}

//break class
public class Break : Job
{
    private int time;
    private bool isBreak;

    public Break(int _time) : base( _time)
    {
        base.setJobTitle("Break");
        base.setJobDescription("");
        is_break = true;
        time = _time;
    }
}


