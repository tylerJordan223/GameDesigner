using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorScript : MonoBehaviour
{
    //window objects for the error script
    [SerializeField] private GameObject errorWindow;
    [SerializeField] private TextMeshProUGUI errorMessage;

    //hides the window on awake
    private void Awake()
    {
        CloseError();
    }

    //methods to show/hide window
    public void ShowError(string message)
    {
        errorWindow.SetActive(true);
        errorMessage.text = message;
    }
    public void CloseError()
    {
        errorWindow.SetActive(false);
    }
}
