using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdTurboBoostPowerUp : MonoBehaviour
{
    private Rigidbody2D _myRigidBody;
    private bool _turboPowerUp;
    private float _turboBoostValue = 300;


    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _turboPowerUp = true;
        }
    }

    private void FixedUpdate()
    {
        if (_turboPowerUp)
        {
            _turboPowerUp = false;

            //add impulse force to the gameobject
            _myRigidBody.AddForce(Vector2.right * _turboBoostValue, ForceMode2D.Impulse);

        }
    }

}
