using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
