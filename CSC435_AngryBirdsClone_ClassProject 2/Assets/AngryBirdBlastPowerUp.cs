using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdBlastPowerUp : MonoBehaviour
{
    private PointEffector2D _myPointEffector;
    private bool _isBlastPowerOn = true;

    // Start is called before the first frame update
    void Start()
    {
        _myPointEffector = GetComponent<PointEffector2D>();
        _myPointEffector.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (_isBlastPowerOn && _myPointEffector.enabled)
        {
            _myPointEffector.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _myPointEffector.enabled = true;
        }
    }
}
