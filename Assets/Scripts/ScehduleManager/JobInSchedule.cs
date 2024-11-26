using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JobInSchedule : MonoBehaviour
{
    //script to handle each job visually when the schedule is generated
    [SerializeField] TextMeshProUGUI job_title;
    [SerializeField] TextMeshProUGUI job_description;
    [SerializeField] TextMeshProUGUI job_time;

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void UpdateJob(Job j)
    {
        job_title.text = j.getJobTitle();
        job_description.text = j.getJobDescription();
        job_time.text = "Days: " + j.getJobTime().ToString();
    }
}
