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
    }
}
