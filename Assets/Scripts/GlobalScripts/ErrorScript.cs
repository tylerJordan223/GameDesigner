using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorScript : MonoBehaviour
{
    //window objects for the error script
    private GameObject error_window_go;
    [SerializeField] private TextMeshProUGUI errorMessage;

    //Initialization method
    public void Init()
    {
        error_window_go = gameObject;

        CloseError();
    }

    //methods to show/hide window
    public void ShowError(string message)
    {
        errorMessage.text = message;
        error_window_go.SetActive(true);
    }
    public void CloseError()
    {
        error_window_go.SetActive(false);
    }
}
