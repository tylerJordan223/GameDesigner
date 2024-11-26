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

    public Job(string _title, string _desc, int _time)
    {
        title = _title;
        desc = _desc;
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

    public Break(string _title, string _desc, int _time) : base(_title, _desc, _time)
    {
        base.setJobTitle("");
        base.setJobDescription("");
        time = _time;
    }
}


