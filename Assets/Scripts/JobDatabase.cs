using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class JobDatabase : MonoBehaviour
{
    public static List<Job> jobs;

    private static string pathToData;

    #region saving/loading
    public static void LoadDatabase()
    {
        //create the list to store all jobs
        jobs = new List<Job>();

        //get the general unity file path
        pathToData = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));

        //makes sure to see if there are any files to load in the first place
        if (!Directory.Exists(pathToData + "/Files/Schedules/"))
        {
            Debug.Log("there is no data to load");
        }
        else
        {
            //get the path to the data and formulate it into one line at a time
            pathToData += "/Files/Schedules/";
            string file_content = File.ReadAllText(pathToData + "Schedule.txt");
            string[] content_lines = file_content.Split("\n");

            //goes through each line to fill out the jobs list ONLY if its not empty
            if(!(content_lines.Length <= 1))
            {
                for (int i = 0; i < content_lines.Length; i++)
                {
                    //if the line is not a boolean then the file was messed with
                    if (!bool.TryParse(content_lines[i].Trim(), out _))
                    {
                        WindowManager.instance.error_window.ShowError("Save Corrupted " + content_lines[i].Trim() + content_lines[content_lines.Length-1]);
                        //generate a new list instead
                        jobs = new List<Job>();
                        break;
                    }

                    //if this is true it is a break
                    if (bool.Parse(content_lines[i]))
                    {
                        i++; //time
                        jobs.Add(new Break(int.Parse(content_lines[i])));
                    }
                    else
                    {
                        //not a break so each line needs to generate a job
                        Job temp_job = new Job("", "", -1, false);
                        i++; //title
                        temp_job.setJobTitle(content_lines[i]);
                        i++; //description
                        temp_job.setJobDescription(content_lines[i]);
                        i++; //time
                        temp_job.setJobTime(int.Parse(content_lines[i]));
                        jobs.Add(temp_job);
                    }

                    //accounting for the last line always being a blank space
                    if(i == content_lines.Length - 2)
                    {
                        i++;
                    }
                }
            }
        }
    }

    public static void SaveDatabase()
    {
        //get the general unity file path
        pathToData = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));

        //check to make sure the folder exists before making it
        if (!Directory.Exists(pathToData + "/Files/Schdules/"))
        {
            Directory.CreateDirectory(pathToData + "/Files/Schedules/");
        }

        pathToData += "/Files/Schedules/";

        //create the file 
        string fileName = pathToData + "Schedule.txt";
        string combinedString = "";

        //create teh data to save
        for(int i = 0; i < jobs.Count; i++)
        {
            Job temp_job = jobs[i];
            if (jobs[i].is_break)
            {
                //if its a break only save two values
                combinedString += jobs[i].is_break.ToString() + "\n";
                combinedString += jobs[i].getJobTime().ToString() + "\n";
            }
            else
            {
                //save all values otherwise
                combinedString += jobs[i].is_break.ToString() + "\n";
                combinedString += jobs[i].getJobTitle() + "\n";
                combinedString += jobs[i].getJobDescription() + "\n";
                combinedString += jobs[i].getJobTime().ToString() + "\n";
            }
        }

        if(File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        
        File.WriteAllText(fileName, combinedString);
           
    }
    #endregion saving/loading

    #region job management
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

    #endregion job management
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


