using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TargetJoint2D))] // automatically add the dependencies
public class AngryBirdMouseController : MonoBehaviour
{

    private Rigidbody2D _myRigidBody;
    public TargetJoint2D _myTargetJoint;
    private GameObject _launchPoint;

    public bool isAimingNow;
    private float _slingshotElasticCapacity = 3.5f;

    [Range(1, 3000)]
    public float birdFlightSpeed;

    private bool _isReleaseBird;

    // Start is called before the first frame update
    void Start()
    {
        // Get the reference for essential components
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myTargetJoint = GetComponent<TargetJoint2D>();

        _launchPoint = GameObject.Find("LaunchPoint");

    }

    // Update is called once per frame
    void Update()
    {
        // check whether user is aiming or not
        if (!isAimingNow)
            return;

        //Slingshot mechanics -------------

        // Extract mouse input from screenspace and map it to world space
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        //Compute mouse delta position - to set elastic capacity
        float mouseDeltaPosition = Vector2.Distance(_launchPoint.transform.position, currentMousePosition);


        if (mouseDeltaPosition < _slingshotElasticCapacity)
        {
            // Set mouse position to target joint(Angrybird)
            _myTargetJoint.target = currentMousePosition;
        }

    }

    private void FixedUpdate()
    {
        if (_isReleaseBird)
        {
            _isReleaseBird = false;

            //Release bird
            ReleaseBird();
        }

    }

    private void OnMouseDown()
    {
        isAimingNow = true;
    }

    private void OnMouseUp()
    {
        isAimingNow = false;
        _myTargetJoint.enabled = false;
        _isReleaseBird = true;

        _myRigidBody.freezeRotation = false;
    }


    private void ReleaseBird()
    {
        // compute bird's trajectory
        Vector2 birdTrajectory = _launchPoint.transform.position - transform.position;

        //Add force to the bird
        _myRigidBody.AddForce(birdTrajectory * birdFlightSpeed, ForceMode2D.Force);

    }
}
