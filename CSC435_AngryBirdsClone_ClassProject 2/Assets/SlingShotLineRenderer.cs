using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotLineRenderer : MonoBehaviour
{
    private LineRenderer _sFrontLine;
    private LineRenderer _sRearLine;
    private AngryBirdMouseController _angryBirdMouseControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        _sFrontLine = GameObject.Find("SFrontPoint").GetComponent<LineRenderer>();
        _sRearLine = GameObject.Find("SRearPoint").GetComponent<LineRenderer>();

        // get reference of angry bird mouse conbtroller

        _angryBirdMouseControllerScript = gameObject.GetComponent<AngryBirdMouseController>();
    }

    // Update is called once per frame
    void Update()
    {
        // render the line when the user aims

        if (_angryBirdMouseControllerScript.isAimingNow)
        {
            EnableLineRenderer();
        }
        else
        {
            DisableLineRenderer();
        }

    }

    private void EnableLineRenderer()
    {
        // enable line renderer
        _sFrontLine.enabled = true;
        _sRearLine.enabled = true;

        // Draw lines
        _sFrontLine.SetPosition(0, _sFrontLine.transform.position);
        _sFrontLine.SetPosition(1, _angryBirdMouseControllerScript._myTargetJoint.transform.position);

        _sRearLine.SetPosition(0, _sRearLine.transform.position);
        _sRearLine.SetPosition(1, _angryBirdMouseControllerScript._myTargetJoint.transform.position);



    }

    private void DisableLineRenderer()
    {
        _sFrontLine.enabled = false;
        _sRearLine.enabled = false;
    }
}
