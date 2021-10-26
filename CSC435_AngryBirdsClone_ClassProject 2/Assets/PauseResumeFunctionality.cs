using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeFunctionality : MonoBehaviour
{

    private bool _isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }


    public void PauseResumeButton()
    {
        _isPaused = !_isPaused;
    }
}
